using CashRegisterNStock.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashRegisterNStock.DAL.Configurations
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.Property(o => o.Total)
                .IsRequired()
                .HasColumnType("decimal(7,2)")
                .HasPrecision(7, 2);
        }
    }
}
