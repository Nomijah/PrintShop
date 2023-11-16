using Microsoft.AspNetCore.DataProtection.Internal;
using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.BLL.Services.Interfaces
{
    public interface IUserService
    {
        public Task<ApiResponse> RegisterNewUser(UserRegisterDto userRegisterDto);
        public Task<ApiResponse> UpdatePassword(
            User user, string newPassword, string oldPassword);
        //public Task<ApiResponse> 

    }
}
