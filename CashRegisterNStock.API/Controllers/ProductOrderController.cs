using AutoMapper;
using CashRegisterNStock.API.DTOs.ProductOrder;
using CashRegisterNStock.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashRegisterNStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProductOrderService _productOrderService;

        public ProductOrderController(IMapper mapper, ProductOrderService productOrderService)
        {
            _mapper = mapper;
            _productOrderService = productOrderService;
        }

        [HttpGet]
        public IActionResult GetAllProductOrders()
        {
            try
            {
                List<ProductOrderIndexDTO> productOrders = _productOrderService.GetAllProductOrders().Select(_mapper.Map<ProductOrderIndexDTO>).ToList();
                return Ok(productOrders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
