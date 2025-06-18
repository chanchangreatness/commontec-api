using ComonTecApi.Models;
using ComonTecApi.Services.Interfaces;

namespace ComonTecApi.Endpoints
{
    public static class ProductsEndpoint
    {
        public static IEndpointRouteBuilder MapProductsEndpoint(this IEndpointRouteBuilder app)
        {
            var apiGroup = app.MapGroup("products").WithTags("Products");

            apiGroup
                .MapPost("/", (ProductDto payload, IProductService service) => service.AddProductAsync(payload))
                .WithName("Add Product");

            apiGroup
                .MapGet("/", (IProductService service, int page = 1) => service.ListProductAsync(page))
                .WithName("List Products");

            apiGroup
                .MapGet("/{id}", (int productId, IProductService service) => service.GetProductAsync(productId))
                .WithName("Get Product by Id");

            apiGroup
                .MapPut("/{id}", (int productId, string name, string description, int quantity, IProductService service) 
                    => service.UpdateProductAsync(productId, name, description, quantity))
                .WithName("Update Product by Id");

            apiGroup
                .MapDelete("/{id}", (int productId, IProductService service) => service.DeleteProductAsync(productId))
                .WithName("Delete Product by Id");

            return apiGroup;
        }
    }
}
