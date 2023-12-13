using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.BLL.Validation.UserValidations;
using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.ResponseDTOs;
using PrintShop.GlobalData.Models.DTOs.UserDTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PrintShop.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<User> userManager,
            IEmailService emailService, IUrlHelperFactory urlHelperFactory, IConfiguration configuration)
        {
            _userManager = userManager;
            _emailService = emailService;
            _urlHelperFactory = urlHelperFactory;
            _configuration = configuration;
        }
        public async Task<ApiResponse> RegisterNewUser(UserRegisterDto userRegisterDto, HttpContext httpContext)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
            var validator = new UserRegistrationValidator();
            var validationResult = await validator.ValidateAsync(userRegisterDto);
            var userExist = await _userManager.FindByEmailAsync(userRegisterDto.Email);

            if (validationResult.IsValid && userExist == null)
            {
                User userToRegister = new User
                {
                    Email = userRegisterDto.Email,
                    UserName = userRegisterDto.Email
                };

                var result = await _userManager.CreateAsync(userToRegister, userRegisterDto.Password);

                if (result.Succeeded)
                {
                    // Add customer role to user
                    await _userManager.AddToRoleAsync(userToRegister, "customer");

                    // Add token
                    var urlHelper = _urlHelperFactory.GetUrlHelper(new ActionContext
                    {
                        HttpContext = httpContext
                    });
                    var token = await _userManager
                        .GenerateEmailConfirmationTokenAsync(userToRegister);
                    var confirmationLink = urlHelper.Action("ConfirmEmail",
                        "User", new { token, userToRegister.Email },
                        urlHelper.ActionContext.HttpContext.Request.Scheme);
                    var message = new Message(new string[] { userToRegister.Email! },
                        "Email confirmation link", confirmationLink!);
                    _emailService.SendEmail(message);

                    response.StatusCode = StatusCodes.Status201Created;
                    response.IsSuccess = true;
                    return response;
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        response.ErrorMessages.Add(error.Description);
                    }
                    return response;
                }
            }
            else
            {
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.ErrorMessages.Add(error.ErrorMessage);
                    }
                }
                if (userExist != null)
                {
                    response.ErrorMessages.Add("User already exists.");
                }
                return response;
            }
        }

        public async Task<ApiResponse> UpdatePassword(PasswordUpdateDto passwordUpdateDto)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var validator = new PasswordUpdateValidator();
            var validationResult = await validator.ValidateAsync(passwordUpdateDto);
            var userToUpdate = await _userManager.FindByEmailAsync(passwordUpdateDto.Email);

            if (validationResult.IsValid && userToUpdate != null)
            {
                var result = await _userManager.ChangePasswordAsync(userToUpdate,
                    passwordUpdateDto.NewPassword, passwordUpdateDto.CurrentPassword);

                if (result.Succeeded)
                {
                    response.StatusCode = StatusCodes.Status200OK;
                    response.IsSuccess = true;
                    return response;
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        response.ErrorMessages.Add(error.Description);
                    }
                    return response;
                }
            }
            else
            {
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.ErrorMessages.Add(error.ErrorMessage);
                    }
                }
                if (userToUpdate == null)
                {
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.ErrorMessages.Add("User not found.");
                }
                return response;
            }
        }

        public async Task<ApiResponse> ConfirmEmail(string token, string email)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    response.StatusCode = StatusCodes.Status200OK;
                    response.IsSuccess = true;
                    return response;
                }
            }

            response.StatusCode = StatusCodes.Status404NotFound;
            response.ErrorMessages.Add("User not found.");
            return response;
        }

        public async Task<ApiResponse> Login(UserLoginDto userLogin)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var validator = new UserLoginValidator();
            var validationResult = await validator.ValidateAsync(userLogin);
            if (!validationResult.IsValid)
            {
                response.ErrorMessages.Add("Both email and password are required.");
                return response;
            }

            var currentUser = await _userManager.FindByEmailAsync(userLogin.UserName);
            if (currentUser == null)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.ErrorMessages.Add("User not found.");
                return response;
            }

            bool passwordConfirmed = await _userManager.CheckPasswordAsync(currentUser, userLogin.Password);
            if (currentUser != null && passwordConfirmed)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, currentUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var userRoles = await _userManager.GetRolesAsync(currentUser);
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var jwtToken = GetToken(authClaims);

                response.IsSuccess = true;
                response.StatusCode = StatusCodes.Status200OK;
                response.Result = new ClaimResponse(jwtToken);
                return response;
            }

            if (!passwordConfirmed)
            {
                response.StatusCode = StatusCodes.Status401Unauthorized;
                response.ErrorMessages.Add("Wrong password.");
            }
            return response;
        }

        // Token generator to be used by Login
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        public async Task<ApiResponse> GetAll()
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
            var users = await _userManager.Users.ToListAsync();

            var result = new List<UserResponseDto>();
            foreach ( var user in users )
            {
                result.Add(new UserResponseDto
                {
                    id = user.Id.ToString(),
                    userName = user.UserName,
                    email = user.Email,
                    emailConfirmed = user.EmailConfirmed
                });
            }

            if (result != null)
            {
                response.IsSuccess = true;
                response.StatusCode = StatusCodes.Status200OK;
                response.Result = result;
                return response;
            }
            return response;
        }

        public async Task<ApiResponse> GetAllWithRoles()
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
            var usersWithRoles = await _userManager.Users.Include(u => u.Roles).ToListAsync();

            var result = new List<UserWithRoleResponseDto>();
            foreach (var user in usersWithRoles)
            {
                result.Add(new UserWithRoleResponseDto
                {
                    id = user.Id.ToString(),
                    userName = user.UserName,
                    email = user.Email,
                    emailConfirmed = user.EmailConfirmed,
                    roles = user.Roles
                });
            }

            if (result != null)
            {
                response.IsSuccess = true;
                response.StatusCode = StatusCodes.Status200OK;
                response.Result = result;
                return response;
            }
            return response;
        }
    }
}
