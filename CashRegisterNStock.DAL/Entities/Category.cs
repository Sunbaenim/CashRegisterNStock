using System.ComponentModel.DataAnnotations;

namespace CashRegisterNStock.DAL.Entities
{
    public class Category
    {
        public required int Id { get; set; }
        [MaxLength(30)]
        public required string Name { get; set; }
        public required List<Product> Products { get; set; }
    }
}
