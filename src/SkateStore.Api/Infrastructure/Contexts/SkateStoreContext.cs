using FluentValidator;
using Microsoft.EntityFrameworkCore;
using SkateStore.Api.Infrastructure.Mappings;
using SkateStore.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkateStore.Api.Infrastructure.Contexts
{
    public class SkateStoreContext : DbContext
    {        
        public SkateStoreContext(DbContextOptions<SkateStoreContext> options)
        : base(options)
        {     
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Product> Products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Notification>();
            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new NewletterMap());
            builder.ApplyConfiguration(new ProductMap());
        }
    }
}
