﻿using Microsoft.AspNetCore.Mvc;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.GlobalData.Models.DTOs.UserDTOs;
using Serilog;

namespace PrintShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(UserRegisterDto userRegisterDto)
        {
            var response = await _userService.RegisterNewUser(userRegisterDto, Url.ActionContext.HttpContext);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPut("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(PasswordUpdateDto passwordUpdateDto)
        {
            var response = await _userService.UpdatePassword(passwordUpdateDto);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var response = await _userService.ConfirmEmail(token, email);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var response = await _userService.Login(userLoginDto);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetAll();
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetUsersWithRoles")]
        public async Task<IActionResult> GetUsersWithRoles()
        {
            var response = await _userService.GetAllWithRoles();
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPut("AddUserToRole")]
        public async Task<IActionResult> AddRoleToUser(string userId, string role)
        {
            var response = await _userService.AddUserToRole(userId, role);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPut("RemoveUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole(string userId, string role)
        {
            var response = await _userService.RemoveUserFromRole(userId, role);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}