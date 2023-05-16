using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegisterNStock.DAL.Entities
{
    public class ProductOrder
    {
        public required int Id { get; set; }
        public required int OrderId { get; set; }
        public required Order Order { get; set; }
        public required int ProductId { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public required int Quantity { get; set; }
        public required DateTime ProductOrderDate { get; set; }

    }
}
