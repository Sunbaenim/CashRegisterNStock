using CashRegisterNStock.API.DTOs.Order;
using CashRegisterNStock.API.DTOs.Product;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegisterNStock.API.DTOs.ProductOrder
{
    public class ProductOrderAddDTO
    {
        public required int ProductId { get; set; }
        [Column(TypeName = "descimal(5, 2)")]
        public required int Quantity { get; set; }
    }
}
