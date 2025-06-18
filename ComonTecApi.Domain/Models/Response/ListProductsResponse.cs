using ComonTecApi.Domain.Entities;

namespace ComonTecApi.Domain.Models.Response
{
    public class ListProductsResponse
    {
        public int ProductCount { get; set; }
        public int TotalPages { get; set; }
        public List<ProductDto>? Products { get; set; }

        public ListProductsResponse(int productCount, List<Product> products)
        {
            ProductCount = productCount;
            TotalPages = (int)Math.Ceiling((double)ProductCount / products.Count);
            Products = products.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Quantity = x.Quantity
            }).ToList();
        }
    }
}
