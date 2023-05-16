﻿namespace CashRegisterNStock.API.DTOs.Product
{
    public class ProductIndexDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public required string ImageUrl { get; set; }
    }
}
