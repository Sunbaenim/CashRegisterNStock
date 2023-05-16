using CashRegisterNStock.API.DTOs.Product;

namespace CashRegisterNStock.API.DTOs.Category
{
    public class CategoryWithProductsIndexDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required List<ProductIndexDTO> Products { get; set; }
    }
}
