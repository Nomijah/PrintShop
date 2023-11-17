using PrintShop.DAL;
using PrintShop.BLL;
using PrintShop.BLL.Validation.UserValidations;
using Serilog;
using FluentValidation;
using PrintShop.GlobalData.Models.DTOs.UserDTOs;
using PrintShopAPI.Middlewares;
using PrintShop.GlobalData.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IValidator<UserRegisterDto>, UserRegistrationValidator>();

// Configuration from DAl and BLL
builder.Services.DbServicesDAL(builder.Configuration).DbServicesBLL(builder.Configuration);

// Add Email Config
builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration"));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<EmailConfiguration>>().Value);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
