using AutoMapper;
using CashRegisterNStock.BLL.Models;
using CashRegisterNStock.DAL.Entities;
using CashRegisterNStock.DAL.Repositories;

namespace CashRegisterNStock.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly OrderRepository _orderRepository;
        private readonly ProductOrderService _productOrderService;
        private readonly ProductRepository _productRepository;

        public OrderService(IMapper mapper, OrderRepository orderRepository, ProductOrderService productOrderService, ProductRepository productRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _productOrderService = productOrderService;
            _productRepository = productRepository;
        }

        public void AddOrder(OrderModel model)
        {
            DateTime date = DateTime.Now;
            model.OrderDate = date;
            foreach (ProductOrderModel productOrder in model.ProductOrders)
            {
                productOrder.ProductOrderDate = date;
                _productRepository.UpdateStockProduct(productOrder.ProductId, productOrder.Quantity);
            }
            Order order = _mapper.Map<Order>(model);
            _orderRepository.AddOrder(order);
        }

        public IEnumerable<OrderModel> GetAllOrders()
        {
            IEnumerable<OrderModel> orders = _orderRepository.GetAllOrders()
                .ToList()
                .Select(o =>
                {
                    OrderModel order = _mapper.Map<OrderModel>(o);
                    List<ProductOrderModel> productOrders = _productOrderService.GetAllProductOrders().ToList();
                    order.ProductOrders = productOrders.Where(po => po.OrderId == order.Id).ToList();
                    return order;
                });
            return orders;
        }
    }
}
