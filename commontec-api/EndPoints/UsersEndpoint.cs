namespace commontec_api.EndPoints
{
    public static class UsersEndpoint
    {
        public static IEndpointRouteBuilder MapUsersEndpoint(this IEndpointRouteBuilder app)
        {
            var apiGroup = app.MapGroup("users");

            apiGroup.MapPost("/me", () =>
            {
                return TypedResults.Ok();
            });

            return app;
        }
    }
}
