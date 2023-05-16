using CashRegisterNStock.API.DTOs.ProductOrder;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegisterNStock.API.DTOs.Order
{
    public class OrderAddDTO
    {
        public required List<ProductOrderAddDTO> ProductOrders { get; set; }
        [Column(TypeName = "decimal(7, 2)")]
        public required float Total { get; set; }
    }
}
