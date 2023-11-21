using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrintShop.BLL.Services;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.BLL.Validation.UserValidations;
using PrintShop.GlobalData.Data;

namespace PrintShop.BLL
{
    public static class BLLConfigureServices
    {
        public static IServiceCollection DbServicesBLL(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddValidatorsFromAssemblyContaining<PasswordUpdateValidator>();

            return services;
        }
    }
}
