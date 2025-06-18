namespace ComonTecApi.Endpoints
{
    public static class ProductsEndpoint
    {
        public static IEndpointRouteBuilder MapProductsEndpoint(this IEndpointRouteBuilder app)
        {
            var apiGroup = app.MapGroup("products").WithTags("Products");

            apiGroup.MapPost("/", () =>
            {
                return TypedResults.Ok("Product Created");
            });

            apiGroup.MapGet("/", () =>
            {
                return TypedResults.Ok("Product List");
            });

            apiGroup.MapGet("/{id}", (int id) => 
            {
                return TypedResults.Ok($"Returned {id}");
            });

            apiGroup.MapPut("/{id}", (int id) => 
            {
                return TypedResults.Ok($"Updated {id}");
            });

            apiGroup.MapDelete("/{id}", (int id) =>
            {
                return TypedResults.Ok($"Deleted {id}");
            });

            return apiGroup;
        }
    }
}
