using ComonTecApi.Domain.Models;
using ComonTecApi.Domain.Models.Response;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ComonTecApi.Application.IServices
{
    public interface IProductService
    {
        Task<Results<Ok<string>, Conflict<string>>> AddProductAsync(ProductDto request);
        Task<Results<Ok<ListProductsResponse>, BadRequest<string>>> ListProductAsync(int page);
        Task<Results<Ok<ProductDto>, BadRequest<string>>> GetProductAsync(int productId);
        Task<Results<Ok<string>, BadRequest<string>>> DeleteProductAsync(int productId);
        Task<Results<Ok<string>, BadRequest<string>>> UpdateProductAsync(int productId, string name, string description, int quantity);
    }
}
