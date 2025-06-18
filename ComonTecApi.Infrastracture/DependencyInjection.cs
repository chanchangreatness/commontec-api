using System.Text;
using ComonTecApi.Application.Services;
using ComonTecApi.Domain.IRepositories;
using ComonTecApi.Domain.IServices;
using ComonTecApi.Infrastracture.Data;
using ComonTecApi.Infrastracture.Repositories;
using ComonTecApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ComonTecApi.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Authentication:Schemes:ValidIssuer"],
                        ValidAudiences = configuration.GetSection("Authentication:Schemes:Bearer:ValidAudiences").Get<string[]>(),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:Schemes:IssuerKey"]!))
                    };
                });

            services.AddAuthorization();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Comontech API",
                    Version = "v1"
                });

                var securityScheme = new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "Add Bearer token here",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                };

                var securityRequirement = new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                };

                options.AddSecurityDefinition("Bearer", securityScheme);
                options.AddSecurityRequirement(securityRequirement);

                options.EnableAnnotations();
            });

            services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("ComontecSchema"));

            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
