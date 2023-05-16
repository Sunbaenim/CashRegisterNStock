using CashRegisterNStock.BLL.Models;

namespace CashRegisterNStock.BLL.Services
{
    public interface IProductOrderService
    {
        IEnumerable<ProductOrderModel> GetAllProductOrders();
    }
}
