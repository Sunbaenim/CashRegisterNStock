using AutoMapper;
using CashRegisterNStock.BLL.Models;
using CashRegisterNStock.DAL.Entities;
using CashRegisterNStock.DAL.Repositories;

namespace CashRegisterNStock.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper, CategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public void CheckIfCategoryExists(CategoryModel model)
        {
            List<CategoryModel> categories = _categoryRepository.GetAllCategories().Select(_mapper.Map<CategoryModel>).ToList();
            if (categories.Any(c => c.Name == model.Name))
            {
                throw new ArgumentException("A Category with the same name already exists.");
            }
        }

        public CategoryModel CreateCategory(CategoryModel model)
        {
            CheckIfCategoryExists(model);
            Category category = _categoryRepository.CreateCategory(_mapper.Map<Category>(model));
            return _mapper.Map<CategoryModel>(category);
        }

        public CategoryModel DeleteCategory(int id)
        {
            Category category = _categoryRepository.DeleteCategory(id);
            return _mapper.Map<CategoryModel>(category);
        }

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories().Select(_mapper.Map<CategoryModel>);
        }

        public IEnumerable<CategoryModel> GetAllCategoriesWithTheirProducts()
        {
            return _categoryRepository.GetAllCategoriesWithTheirProducts().Select(_mapper.Map<CategoryModel>);
        }

        public CategoryModel GetCategoryById(int id)
        {
            Category category = _categoryRepository.GetCategoryById(id);
            return _mapper.Map<CategoryModel>(category);
        }

        public CategoryModel UpdateCategory(int id, CategoryModel model)
        {
            CheckIfCategoryExists(model);
            Category category = _categoryRepository.UpdateCategory(id, _mapper.Map<Category>(model));
            return _mapper.Map<CategoryModel>(category);
        }
    }
}
