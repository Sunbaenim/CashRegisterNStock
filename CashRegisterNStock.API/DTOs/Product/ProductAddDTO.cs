using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CashRegisterNStock.API.DTOs.Product
{
    public class ProductAddDTO
    {
        public required int CategoryId { get; set; }
        [MaxLength(15)]
        public required string Name { get; set; }
        [MaxLength(15)]
        public required string Description { get; set; }
        [Column(TypeName = "descimal(5, 2)")]
        public required decimal Price { get; set; }
        public required int Stock { get; set; }
        public required string ImageUrl { get; set; }
    }
}
