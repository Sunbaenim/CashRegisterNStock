using AutoMapper;
using CashRegisterNStock.API.DTOs.Product;
using CashRegisterNStock.BLL.Models;
using CashRegisterNStock.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashRegisterNStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProductService _productService;

        public ProductController(IMapper mapper, ProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                List<ProductIndexDTO> products = _productService.GetAllProducts().Select(_mapper.Map<ProductIndexDTO>).ToList();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("id")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                ProductIndexDTO dto = _mapper.Map<ProductIndexDTO>(_productService.GetProductById(id));
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public IActionResult CreateProduct(ProductAddDTO dto)
        {
            try
            {
                ProductModel model = _mapper.Map<ProductModel>(dto);
                ProductIndexDTO returnedDto = _mapper.Map<ProductIndexDTO>(_productService.CreateProduct(model));
                return Ok(returnedDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductUpdateDTO dto)
        {
            try
            {
                ProductModel model = _mapper.Map<ProductModel>(dto);
                model.Id = id;
                ProductIndexDTO returnedDto = _mapper.Map<ProductIndexDTO>(_productService.UpdateProduct(id, model));
                return Ok(returnedDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                ProductIndexDTO dto = _mapper.Map<ProductIndexDTO>(_productService.DeleteProduct(id));
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
