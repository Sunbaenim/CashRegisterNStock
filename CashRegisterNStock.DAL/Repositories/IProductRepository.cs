using CashRegisterNStock.DAL.Entities;

namespace CashRegisterNStock.DAL.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        Product CreateProduct(Product entity);
        Product UpdateProduct(int id, Product entity);
        Product DeleteProduct(int id);
    }
}
