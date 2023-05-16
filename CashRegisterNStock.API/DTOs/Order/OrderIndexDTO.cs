using CashRegisterNStock.API.DTOs.ProductOrder;

namespace CashRegisterNStock.API.DTOs.Order
{
    public class OrderIndexDTO
    {
        public required int Id { get; set; }
        public required List<ProductOrderIndexDTO> ProductOrders { get; set; }
        public required DateTime OrderDate { get; set; }
        public required float Total { get; set; }
    }
}
