using Bogus;
using ComonTecApi.Entities;

namespace ComonTecApi.Data
{
    public class DataSeeder
    {
        private readonly AppDbContext _context;

        public DataSeeder(AppDbContext context)
        {
            _context = context;
        }

        public void SeedProducts()
        {
            var id = 1;
            var fakeProducts = new Faker<Product>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Quantity, f => (int)f.Finance.Amount(min: 0, max: 100, decimals: 0));

            _context.Set<Product>().AddRange(fakeProducts.Generate(100));

            _context.SaveChanges();
        }
    }
}
