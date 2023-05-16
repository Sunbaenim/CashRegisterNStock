using CashRegisterNStock.BLL.Models;

namespace CashRegisterNStock.BLL.Services
{
    public interface IOrderService
    {
        void AddOrder(OrderModel model);
    }
}
