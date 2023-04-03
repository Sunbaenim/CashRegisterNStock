using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegisterNStock.DAL.Entities
{
    public class Product
    {
        public required int Id { get; set; }
        public required int CategoryId { get; set; }
        public required Category Category { get; set; }
        [MaxLength(15)]
        public required string Name { get; set; }
        [MaxLength(15)]
        public required string Description { get; set; }
        [Column(TypeName = "descimal(5, 2)")]
        public required decimal Price { get; set; }
        public required int Stock { get; set; }
        [MaxLength(100)]
        public required string ImageUrl { get; set; }
    }
}
