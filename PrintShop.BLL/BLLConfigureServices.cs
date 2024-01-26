using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrintShop.BLL.Services;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.BLL.Validation.UserValidations;

namespace PrintShop.BLL
{
    public static class BLLConfigureServices
    {
        public static IServiceCollection DbServicesBLL(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPrintSizeService, PrintSizeService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IVariantService, VariantService>();
            services.AddScoped<IPictureService, PictureService>();
            services.AddScoped<IBlobService, BlobService>();
            services.AddScoped<ICreatorIdService, CreatorIdService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddValidatorsFromAssemblyContaining<PasswordUpdateValidator>();

            return services;
        }
    }
}
