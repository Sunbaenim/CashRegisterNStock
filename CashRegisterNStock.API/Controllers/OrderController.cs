using AutoMapper;
using CashRegisterNStock.API.DTOs.Order;
using CashRegisterNStock.BLL.Models;
using CashRegisterNStock.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashRegisterNStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly OrderService _orderService;
        private readonly ProductOrderService _productOrderService;

        public OrderController(IMapper mapper, OrderService orderService, ProductOrderService productOrderService)
        {
            _mapper = mapper;
            _orderService = orderService;
            _productOrderService = productOrderService;
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderAddDTO dto)
        {
            try
            {
                OrderModel orderModel = _mapper.Map<OrderModel>(dto);
                _orderService.AddOrder(orderModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            try
            {
                List<OrderIndexDTO> orders = _orderService.GetAllOrders().Select(_mapper.Map<OrderIndexDTO>).ToList();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
