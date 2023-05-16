using CashRegisterNStock.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashRegisterNStock.DAL.Configurations
{
    internal class ProductOrderConfig : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.HasOne(po => po.Order)
                .WithMany(o => o.ProductOrders)
                .IsRequired();

            builder.Property(po => po.ProductId)
                .IsRequired();

            builder.Property(po => po.Quantity)
                .IsRequired();

            builder.Property(po => po.ProductOrderDate)
                .IsRequired();
        }
    }
}
