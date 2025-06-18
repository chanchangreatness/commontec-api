using ComonTecApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComonTecApi.Infrastracture.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
