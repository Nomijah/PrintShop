using Microsoft.AspNetCore.Http;
using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models.DTOs.UserDTOs;

namespace PrintShop.BLL.Services.Interfaces
{
    public interface IUserService
    {
        public Task<ApiResponse> RegisterNewUser(UserRegisterDto userRegisterDto, HttpContext httpContext);
        public Task<ApiResponse> UpdatePassword(PasswordUpdateDto passwordUpdateDto);
        public Task<ApiResponse> ConfirmEmail(string token, string email);

    }
}
