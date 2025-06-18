using ComonTecApi.Data;
using ComonTecApi.Entities;
using ComonTecApi.Extensions;
using ComonTecApi.Models;
using ComonTecApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComonTecApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProductAsync(ProductDto request)
        {
            var product = _context.Products.FirstOrDefault(e => e.Name == request.Name);

            if (product is not null)
            {
                return false;
            }

            await _context.Products.AddAsync(new Product
            {
                Name = request.Name,
                Description = request.Description,
                Quantity = request.Quantity
            });

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(e => e.Id == productId);

            if (product is null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Product?> GetProductAsync(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(e => e.Id == productId);
        }

        public async Task<List<Product>> ListProductAsync(int page)
        {
            return await _context.Products.AsQueryable().Page(page, 10).ToListAsync();
        }

        public async Task<int> CountProductAsync()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<string> UpdateProductAsync(int productId, string name, string description, int quantity)
        {
            var product = await _context.Products.FirstOrDefaultAsync(e => e.Id == productId);

            if (product is null)
            {
                return "Product doesn't exist";
            }

            if (product.Name == name)
            {
                return "Product name must be unique";
            }

            product.Name = name;
            product.Description = description;
            product.Quantity = quantity;

            _context.Products.Update(product);

            await _context.SaveChangesAsync();

            return "Product updated";
        }
    }
}
