using Microsoft.AspNetCore.Authorization;

namespace ComonTecApi.Endpoints
{
    public static class UsersEndpoint
    {
        public static IEndpointRouteBuilder MapUsersEndpoint(this IEndpointRouteBuilder app)
        {
            var apiGroup = app.MapGroup("users").WithTags("Users");

            apiGroup.MapPost("/me",
                [Authorize] () =>
            {
                return TypedResults.Ok();
            });

            return apiGroup;
        }
    }
}
