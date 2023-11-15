using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrintShop.DAL.Context;
using PrintShop.DAL.Repositories;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            services.AddScoped<IRepository<Product>, ProductRepo>();
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
