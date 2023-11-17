
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IEmailService _emailService;

        public AuthenticationService(IEmailService emailService)
        {

            _emailService = emailService;

        }
        public ApiResponse EmailVerification()
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
            var message = new Message(new[] {
                "petter.bostrom@gmail.com", "petter_bos@hotmail.com" }, 
                "Testmail", "<h1>Tjohoo!</h1><h5>Bla</h5>");

            _emailService.SendEmail(message);

            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }
    }
}
