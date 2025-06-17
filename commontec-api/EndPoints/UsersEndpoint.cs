namespace ComonTecApi.EndPoints
{
    public static class UsersEndpoint
    {
        public static IEndpointRouteBuilder MapUsersEndpoint(this IEndpointRouteBuilder app)
        {
            var apiGroup = app.MapGroup("users").WithTags("Users");

            apiGroup.MapPost("/me", () =>
            {
                return TypedResults.Ok();
            });

            return apiGroup;
        }
    }
}
