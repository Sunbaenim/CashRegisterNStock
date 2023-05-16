using CashRegisterNStock.API.DTOs.Product;

namespace CashRegisterNStock.API.DTOs.ProductOrder
{
    public class ProductOrderIndexDTO
    {
        public required ProductIndexDTO Product { get; set; }
        public required int Quantity { get; set; }
        public required DateTime ProductOrderDate { get; set;}
    }
}
