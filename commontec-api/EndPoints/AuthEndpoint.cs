using System.Net;

namespace ComonTecApi.EndPoints
{
    public static class AuthEndPoint
    {
        public static IEndpointRouteBuilder MapAuthEndpoint(this IEndpointRouteBuilder app)
        {
            var apiGroup = app.MapGroup("auth").WithTags("Auth");

            apiGroup.MapPost("/register", () =>
            {
                return TypedResults.Ok();
            });

            apiGroup.MapPost("/login", () => 
            {
                return TypedResults.Ok();
            });

            return apiGroup;
        }
    }
}
