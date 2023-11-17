using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrintShop.DAL.Context;
using PrintShop.DAL.Repositories;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Models;

namespace PrintShop.DAL
{
    public static class ConfigureServices
    {
        public static IServiceCollection DbServicesDAL(
    this IServiceCollection services,
    IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("LocalConnection")));

            services.AddScoped<IRepository<Product>, GeneralRepository<Product>>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();



            return services;
        }
    }
}
