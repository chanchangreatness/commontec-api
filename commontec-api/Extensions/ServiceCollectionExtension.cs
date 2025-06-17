using ComonTecApi.Services;
using ComonTecApi.Data;
using ComonTecApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ComonTecApi.Repositories.Interfaces;
using ComonTecApi.Repositories;

namespace ComonTecApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddAuthentication().AddJwtBearer();
            services.AddAuthorization();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("ComontecSchema"));

            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
