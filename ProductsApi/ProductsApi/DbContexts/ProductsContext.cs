using Microsoft.EntityFrameworkCore;
using ProductsApi.Entities;

namespace ProductsApi.DbContexts
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}
