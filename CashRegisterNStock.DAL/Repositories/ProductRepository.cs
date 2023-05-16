using AutoMapper;
using CashRegisterNStock.DAL.Entities;

namespace CashRegisterNStock.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly CrnsDbContext _context;

        public ProductRepository(IMapper mapper, CrnsDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Product CheckIfProductExistsById(int id)
        {
            Product? product = _context.Products.Find(id) ?? throw new ArgumentException($"No product with the id \"{id}\" was found");
            return product;
        }

        public Product CreateProduct(Product entity)
        {
            Product product = (_context.Products.Add(entity)).Entity;
            _context.SaveChanges();
            return product;
        }

        public Product DeleteProduct(int id)
        {
            Product product = CheckIfProductExistsById(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public Product GetProductById(int id)
        {
            Product product = CheckIfProductExistsById(id);
            return product;
        }

        public Product GetProductByIdForOrder(int id)
        {
            Product product = _context.Products.Find(id);
            return product ?? null;
        }

        public Product UpdateProduct(int id, Product entity)
        {
            Product product = CheckIfProductExistsById(id);
            _mapper.Map(entity, product);
            _context.SaveChanges();
            return product;
        }

        public void UpdateStockProduct(int id, int quantity)
        {
            Product product = CheckIfProductExistsById(id);
            product.Stock -= quantity;
        }
    }
}
