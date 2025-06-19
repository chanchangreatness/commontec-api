using ComonTecApi.Application.IServices;
using ComonTecApi.Application.IRepositories;
using ComonTecApi.Domain.Models;
using ComonTecApi.Domain.Models.Response;
using Microsoft.AspNetCore.Http;
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

        public async Task<Results<Ok<ListProductsResponse>, BadRequest<string>>> ListProductAsync(int page)
        {
            if (page == 0)
            {
                page = 1;
            }

            var products = await _productRepository.ListProductAsync(page);

            var response = new ListProductsResponse(await _productRepository.CountProductAsync(), products);

            if (response.TotalPages < page)
            {
                return TypedResults.BadRequest("Page exceeded the available total pages");
            }

            return TypedResults.Ok(response);
        }

        public async Task<Results<Ok<string>, BadRequest<string>>> UpdateProductAsync(int productId, string name, string description, int quantity)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || quantity < 0)
            {
                return TypedResults.BadRequest("Invalid parameters");
            }

            return TypedResults.Ok(await _productRepository.UpdateProductAsync(productId, name, description, quantity));
        }
    }
}
