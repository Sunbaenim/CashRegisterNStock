using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CashRegisterNStock.BLL.Models
{
    public class ProductModel
    {
        public required int Id { get; set; }
        public required int CategoryId { get; set; }
        [MaxLength(15)]
        public required string Name { get; set; }
        [MaxLength(15)]
        public required string Description { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public required decimal Price { get; set; }
        public required int Stock { get; set; }
        [MaxLength(100)]
        public string? ImageUrl { get; set; }
    }
}
