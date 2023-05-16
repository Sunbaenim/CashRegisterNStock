using AutoMapper;
using CashRegisterNStock.BLL.Models;
using CashRegisterNStock.DAL.Repositories;

namespace CashRegisterNStock.BLL.Services
{
    public class ProductOrderService : IProductOrderService
    {
        private readonly IMapper _mapper;
        private readonly ProductOrderRepository _productOrderRepository;
        private readonly ProductRepository _productRepository;

        public ProductOrderService(IMapper mapper, ProductOrderRepository productOrderRepository, ProductRepository productRepository)
        {
            _mapper = mapper;
            _productOrderRepository = productOrderRepository;
            _productRepository = productRepository;
        }

        public IEnumerable<ProductOrderModel> GetAllProductOrders()
        {
            IEnumerable<ProductOrderModel> productOrders = _productOrderRepository.GetAllProductOrders()
                .ToList()
                .Select(po =>
                {
                    ProductOrderModel productOrder = _mapper.Map<ProductOrderModel>(po);
                    productOrder.Product = _mapper.Map<ProductModel>(_productRepository.GetProductByIdForOrder(po.ProductId));
                    return productOrder;
                });
            return productOrders;
        }
    }
}
