using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegisterNStock.DAL.Entities
{
    public class Order
    {
        public required int Id { get; set; }
        public required List<ProductOrder> ProductOrders { get; set; }
        public required DateTime OrderDate { get; set; }
        [Column(TypeName = "decimal(7, 2)")]
        public required float Total { get; set; }
    }
}
