using ComonTecApi.Entities;
using ComonTecApi.Models;
using ComonTecApi.Models.Response;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ComonTecApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<Results<Ok<string>, Conflict<string>>> AddProductAsync(ProductDto request);
        Task<Ok<ListProductsResponse>> ListProductAsync(int page);
        Task<Results<Ok<ProductDto>, BadRequest<string>>> GetProductAsync(int productId);
        Task<Results<Ok<string>, BadRequest<string>>> DeleteProductAsync(int productId);
        Task<Results<Ok<string>, BadRequest<string>>> UpdateProductAsync(int productId, string name, string description, int quantity);
    }
}
