using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegisterNStock.BLL.Models
{
    public class ProductOrderModel
    {
        public required int Id { get; set; }
        public required int OrderId { get; set; }
        public required OrderModel Order { get; set; }
        public required int ProductId { get; set; }
        public required ProductModel Product { get; set; }
        [Column(TypeName = "descimal(5, 2)")]
        public required int Quantity { get; set; }
        public required DateTime ProductOrderDate { get; set; }

    }
}
