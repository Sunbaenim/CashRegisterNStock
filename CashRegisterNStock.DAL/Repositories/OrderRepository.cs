using CashRegisterNStock.DAL.Entities;

namespace CashRegisterNStock.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CrnsDbContext _context;

        public OrderRepository(CrnsDbContext context)
        {
            _context = context;
        }

        public void AddOrder(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders;
        }
    }
}
