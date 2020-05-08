using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkateStore.Api.Model;

namespace SkateStore.Api.Infrastructure.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                //.HasMaxLength(100) <-- Não está funcionando.
                .HasColumnType("varchar(100)");
                
        }
    }

    public class NewletterMap : IEntityTypeConfiguration<Newsletter>
    {
        public void Configure(EntityTypeBuilder<Newsletter> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.EmailAddress)
                .IsRequired()
                .HasColumnType("varchar(100)");
                
        }
    }

    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()                
                .HasColumnType("varchar(100)");


            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");
                
        }
    }
}
