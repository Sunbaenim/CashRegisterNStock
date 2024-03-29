﻿using CashRegisterNStock.DAL.Configurations;
using CashRegisterNStock.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashRegisterNStock.DAL
{
    public class CrnsDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Order> Orders { get; set; }

        public CrnsDbContext(DbContextOptions<CrnsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ProductOrderConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
        }
    }
}
