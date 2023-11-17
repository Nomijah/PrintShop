using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrintShop.DAL.Context;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.DAL.Repositories;
using PrintShop.GlobalData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.BLL.Services;
using FluentValidation;
using PrintShop.BLL.Validation;
using PrintShop.GlobalData.Models.DTOs;

namespace PrintShop.BLL
{
    public static class ConfigureServices
    {
        public static IServiceCollection DbServicesBLL(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddValidatorsFromAssemblyContaining<UserRegistrationValidator>();
            services.AddScoped<IValidator<UserRegisterDto>, UserRegistrationValidator>();


            return services;
        }
    }
}
