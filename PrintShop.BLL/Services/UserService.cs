using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.DAL.Repositories;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IValidator<UserRegisterDto> _userValidator;

        public UserService(IUserRepo userRepo, UserManager<User> userManager, 
            IConfiguration configuration, IValidator<UserRegisterDto> userValidator)
        {
            _userRepo = userRepo;
            _userManager = userManager; 
            _configuration = configuration;
            _userValidator = userValidator;
        }
        public async Task<ApiResponse> RegisterNewUser(UserRegisterDto userRegisterDto)
        {
            ApiResponse response = new ApiResponse() {
                IsSuccess = false, StatusCode = StatusCodes.Status400BadRequest };
            var validationResult = await _userValidator.ValidateAsync(userRegisterDto);
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
                    await _userManager.AddToRoleAsync(userToRegister, "customer");
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
                if (userExist != null)
                {
                    response.ErrorMessages.Add("User already exists.");
                }
                return response;
            }
        }

        public Task<ApiResponse> UpdatePassword(User user, string newPassword, string oldPassword)
        {
            throw new NotImplementedException();
        }
    }
}
