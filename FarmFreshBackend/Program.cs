using AutoMapper;
using Core.Helper;
using Core.Interfaces;
using Core.Models.Users;
using FarmFreshBackend;
using FarmFreshBackend.DataSet;
using FarmFreshBackend.Extensions;
using FarmFreshBackend.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace FarmFreshBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddSwaggerDocumentation();

            // Configure Serilog
            builder.Host.UseSerilog((context, config) =>
                config.ReadFrom.Configuration(context.Configuration));

            var app = builder.Build();

            // Configure the HTTP request pipeline
            app.UseCustomMiddleware();

            app.Run();
        }


   //     static IHostBuilder CreateHostBuilder(string[] args) =>
   //Host.CreateDefaultBuilder(args)
   //    .UseSerilog() // Use Serilog for logging
   //    .ConfigureServices((hostContext, services) =>
   //    {
   //        // Add your services here
   //    });
    }
}