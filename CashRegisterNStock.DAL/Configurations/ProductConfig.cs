using CashRegisterNStock.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashRegisterNStock.DAL.Configurations
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(5,2)")
                .HasPrecision(5, 2);

            builder.Property(p => p.Stock)
                .IsRequired();

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
