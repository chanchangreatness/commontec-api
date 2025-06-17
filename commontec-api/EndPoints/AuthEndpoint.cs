using System.Net;

namespace commontec_api.EndPoints
{
    public static class AuthEndPoint
    {
        public static IEndpointRouteBuilder MapAuthEndpoint(this IEndpointRouteBuilder app)
        {
            var apiGroup = app.MapGroup("auth");

            apiGroup.MapPost("/register", () =>
            {
                return TypedResults.Ok();
            });

            apiGroup.MapPost("/login", () => 
            {
                return TypedResults.Ok();
            });

            return app;
        }
    }
}
