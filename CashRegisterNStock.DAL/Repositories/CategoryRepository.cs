using AutoMapper;
using CashRegisterNStock.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashRegisterNStock.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMapper _mapper;
        private readonly CrnsDbContext _context;

        public CategoryRepository(IMapper mapper, CrnsDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Category CheckIfCategoryExistsById(int id)
        {
            Category? category = _context.Categories.Find(id) ?? throw new ArgumentException($"No category with the id \"{id}\" was found");
            return category;
        }

        public Category CreateCategory(Category entity)
        {
            Category category = (_context.Categories.Add(entity)).Entity;
            _context.SaveChanges();
            return category;
        }

        public Category DeleteCategory(int id)
        {
            Category? category = CheckIfCategoryExistsById(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }

        public IEnumerable<Category> GetAllCategoriesWithTheirProducts()
        {
            return _context.Categories.Include(c => c.Products);
        }

        public Category GetCategoryById(int id)
        {
            Category? category = CheckIfCategoryExistsById(id);
            return category;
        }

        public Category UpdateCategory(int id, Category entity)
        {
            Category category = CheckIfCategoryExistsById(id);
            _mapper.Map(entity, category);
            _context.SaveChanges();
            return category;
        }
    }
}
