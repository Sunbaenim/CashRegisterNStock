using AutoMapper;
using CashRegisterNStock.API.DTOs.Category;
using CashRegisterNStock.BLL.Models;
using CashRegisterNStock.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashRegisterNStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CategoryService _categoryService;

        public CategoryController(IMapper mapper, CategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAllCategories(bool includeProducts = false)
        {
            try
            {
                if (includeProducts)
                {
                    List<CategoryWithProductsIndexDTO> categories = _categoryService.GetAllCategoriesWithTheirProducts().Select(_mapper.Map<CategoryWithProductsIndexDTO>).ToList();
                    return Ok(categories);
                }
                else
                {
                    List<CategoryIndexDTO> categories = _categoryService.GetAllCategories().Select(_mapper.Map<CategoryIndexDTO>).ToList();
                    return Ok(categories);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("id")]
        public IActionResult GetCategory(int id)
        {
            try
            {
                CategoryModel model = _categoryService.GetCategoryById(id);
                CategoryIndexDTO category = _mapper.Map<CategoryIndexDTO>(model);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryAddDTO dto)
        {
            try
            {
                CategoryModel model = _mapper.Map<CategoryModel>(dto);
                CategoryIndexDTO returnedDto = _mapper.Map<CategoryIndexDTO>(_categoryService.CreateCategory(model));
                return Ok(returnedDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CategoryAddDTO dto)
        {
            try
            {
                CategoryModel model = _mapper.Map<CategoryModel>(dto);
                model.Id = id;
                CategoryIndexDTO returnedDto = _mapper.Map<CategoryIndexDTO>(_categoryService.UpdateCategory(id, model));
                return Ok(returnedDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                CategoryIndexDTO returnDto = _mapper.Map<CategoryIndexDTO>(_categoryService.DeleteCategory(id));
                return Ok(returnDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
