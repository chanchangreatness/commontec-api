using ComonTecApi.Entities;
using ComonTecApi.Models;

namespace ComonTecApi.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> AddProductAsync(ProductDto request);
        Task<List<Product>> ListProductAsync(int page);
        Task<Product?> GetProductAsync(int productId);
        Task<bool> DeleteProductAsync(int productId);
        Task<string> UpdateProductAsync(int productId, string name, string description, int quantity);
        Task<int> CountProductAsync();
    }
}
