using CashRegisterNStock.BLL.Models;

namespace CashRegisterNStock.BLL.Services
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAllProducts();
        ProductModel GetProductById(int id);
        ProductModel CreateProduct(ProductModel model);
        ProductModel UpdateProduct(int id, ProductModel model);
        ProductModel DeleteProduct(int id);
    }
}
