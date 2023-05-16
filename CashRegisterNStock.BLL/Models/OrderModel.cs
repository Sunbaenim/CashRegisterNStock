using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegisterNStock.BLL.Models
{
    public class OrderModel
    {
        public required int Id { get; set; }
        public required List<ProductOrderModel> ProductOrders { get; set; }
        public required DateTime OrderDate { get; set; }

        [Column(TypeName = "decimal(7, 2)")]
        public required float Total { get; set; }
    }
}
