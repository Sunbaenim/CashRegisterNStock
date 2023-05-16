using CashRegisterNStock.DAL.Entities;

namespace CashRegisterNStock.DAL.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Category> GetAllCategoriesWithTheirProducts();
        Category GetCategoryById(int id);
        Category CreateCategory(Category entity);
        Category UpdateCategory(int id, Category entity);
        Category DeleteCategory(int id);
    }
}
