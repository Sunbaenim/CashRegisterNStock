using CashRegisterNStock.DAL.Entities;

namespace CashRegisterNStock.DAL.Repositories
{
    public class ProductOrderRepository : IProductOrderRepository
    {
        private readonly CrnsDbContext _context;

        public ProductOrderRepository(CrnsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductOrder> GetAllProductOrders()
        {
            return _context.ProductOrders;
        }

        public ProductOrder GetProductOrderById(int id)
        {
            return _context.ProductOrders.Find(id) ?? throw new ArgumentException($"No product order with the id \"{id}\" was found");
        }
    }
}
