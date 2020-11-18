using System.Collections.Generic;
using System.Linq;
using BlazingShop.Data;

namespace BlazingShop.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Category GetCategory(int categoryId)
        {
            Category category = new Category();
            return _applicationDbContext.Categories.FirstOrDefault(x => x.Id == categoryId);
        }
        
        public List<Category> GetCategories()
        {
            return _applicationDbContext.Categories.ToList();
        }
        
        public bool CreateCategory(Category category)
        {
            _applicationDbContext.Categories.Add(category);
            bool success = _applicationDbContext.SaveChanges() > 0;
            return success;
        }
        
        public bool UpdateCategory(Category category)
        {

            Category existingCategory = _applicationDbContext.Categories.FirstOrDefault(x => x.Id == category.Id);

            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                _applicationDbContext.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        
        public bool DeleteCategory(Category category)
        {
            Category existingCategory = _applicationDbContext.Categories.FirstOrDefault(x => x.Id == category.Id);

            if (existingCategory != null)
            {
                _applicationDbContext.Categories.Remove(existingCategory);
                _applicationDbContext.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}