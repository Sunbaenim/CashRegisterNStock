using CashRegisterNStock.BLL.Models;

namespace CashRegisterNStock.BLL.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryModel> GetAllCategories();
        IEnumerable<CategoryModel> GetAllCategoriesWithTheirProducts();
        CategoryModel GetCategoryById(int id);
        CategoryModel CreateCategory(CategoryModel model);
        CategoryModel UpdateCategory(int id, CategoryModel model);
        CategoryModel DeleteCategory(int id);
    }
}
