using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.BLL.Validation.UserValidations;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.UserDTOs;

namespace PrintShop.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly IUrlHelperFactory _urlHelperFactory;

        public UserService(IUserRepo userRepo, UserManager<User> userManager, 
            IEmailService emailService, IUrlHelperFactory urlHelperFactory)
        {
            _userRepo = userRepo;
            _userManager = userManager;
            _emailService = emailService;
            _urlHelperFactory = urlHelperFactory;
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
            var userExist = await _userRepo.GetByEmailAsync(userRegisterDto.Email);

            if (validationResult.IsValid && userExist == null)
            {
                User userToRegister = new User
                {
                    Email = userRegisterDto.Email,
                    UserName = userRegisterDto.Email
                };

                var result = await _userRepo.AddAsync(userToRegister, userRegisterDto.Password);

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
            var userToUpdate = await _userRepo.GetByEmailAsync(passwordUpdateDto.Email);

            if (validationResult.IsValid && userToUpdate != null)
            {
                var result = await _userRepo.UpdatePasswordAsync(userToUpdate,
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
                    response.StatusCode= StatusCodes.Status404NotFound;
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
    }
}
