using ComonTecApi.Application.IServices;
using ComonTecApi.Domain.Models;

namespace ComonTecApi.Endpoints
{
    public static class AuthEndpoint
    {
        public static IEndpointRouteBuilder MapAuthEndpoint(this IEndpointRouteBuilder app)
        {
            var apiGroup = app.MapGroup("auth").WithTags("Auth");

            apiGroup.MapPost("/register", (UserDto payload, IAuthService service) => service.RegisterUser(payload));

            apiGroup.MapPost("/login", (UserDto payload, IAuthService service) => service.Login(payload));

            return apiGroup;
        }
    }
}
