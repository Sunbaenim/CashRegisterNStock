using System.ComponentModel.DataAnnotations;

namespace CashRegisterNStock.BLL.Models
{
    public class CategoryModel
    {
        public required int Id { get; set; }
        [MaxLength(30)]
        public required string Name { get; set; }
        public required List<ProductModel> Products { get; set; }
    }
}
