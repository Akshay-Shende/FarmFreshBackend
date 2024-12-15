using AutoMapper;
using Core.Helper;
using Core.Interfaces;
using Core.Models.Users;
using FarmFreshBackend.DataSet;
using FarmFreshBackend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FarmFreshBackend.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRazorPages();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 19)) // Replace with your MySQL version
                );
            });

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<Repository<User>>();
            services.AddTransient<UserRepository>();
            services.AddAutoMapper(typeof(AutoMappingProfiles).Assembly);

            return services;
        }

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1",
                    Description = "A sample API for learning purposes"
                });
            });

            return services;
        }
    }

}
