using CashRegisterNStock.DAL.Entities;

namespace CashRegisterNStock.DAL.Repositories
{
    public interface IProductOrderRepository
    {
        IEnumerable<ProductOrder> GetAllProductOrders();
    }
}
