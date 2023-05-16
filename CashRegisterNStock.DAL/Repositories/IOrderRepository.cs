using CashRegisterNStock.DAL.Entities;

namespace CashRegisterNStock.DAL.Repositories
{
    public interface IOrderRepository
    {
        void AddOrder(Order entity);
    }
}
