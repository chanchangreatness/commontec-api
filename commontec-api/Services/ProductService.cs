using ComonTecApi.Entities;
using ComonTecApi.Models;
using ComonTecApi.Models.Response;
using ComonTecApi.Repositories.Interfaces;
using ComonTecApi.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ComonTecApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public async Task<Results<Ok<string>, Conflict<string>>> AddProductAsync(ProductDto request)
        {
            var isAdded = await _productRepository.AddProductAsync(request);

            return isAdded ? TypedResults.Ok("Product added") : TypedResults.Conflict("Product already exists");
        }

        public async Task<Results<Ok<string>, BadRequest<string>>> DeleteProductAsync(int productId)
        {
            var isDeleted = await _productRepository.DeleteProductAsync(productId);

            return isDeleted ? TypedResults.Ok("Product deleted") : TypedResults.BadRequest("Invalid Product Id");
        }

        public async Task<Results<Ok<ProductDto>, BadRequest<string>>> GetProductAsync(int productId)
        {
            var product = await _productRepository.GetProductAsync(productId);

            if (product is null)
            {
                return TypedResults.BadRequest("Invalid Product Id");
            }

            return TypedResults.Ok(new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Quantity = product.Quantity,
            });
        }

        public async Task<Ok<ListProductsResponse>> ListProductAsync(int page)
        {
            var products = await _productRepository.ListProductAsync(page);

            return TypedResults.Ok(new ListProductsResponse(await _productRepository.CountProductAsync(), products));
        }

        public async Task<Results<Ok<string>, BadRequest<string>>> UpdateProductAsync(int productId, string name, string description, int quantity)
        {
            return TypedResults.Ok(await _productRepository.UpdateProductAsync(productId, name, description, quantity));
        }
    }
}
