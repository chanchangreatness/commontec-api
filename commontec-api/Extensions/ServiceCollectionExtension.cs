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

            return services;
        }
    }
}
