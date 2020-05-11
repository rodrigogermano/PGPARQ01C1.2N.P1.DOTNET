using FluentValidator;
using Microsoft.EntityFrameworkCore;
using SkateStore.Products.Domain.Entities;
using SkateStore.Products.Infra.Data.Mappings;

namespace SkateStore.Products.Infra.Data.Contexts
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Notification>();
            builder.ApplyConfiguration(new ProductMap());
        }
    }
}
