using System.Collections.Generic;
using System.Linq;
using BlazingShop.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Product GetProduct(int productId)
        {
            return _applicationDbContext.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == productId);
        }

        public List<Product> GetProducts()
        {
            return _applicationDbContext.Products.Include(x => x.Category).ToList();
        }
        
        public List<Category> GetCategoryList()
        {
            return _applicationDbContext.Categories.ToList();
        }

        public bool CreateCategory(Product product)
        {
            _applicationDbContext.Products.Add(product);
            bool success = _applicationDbContext.SaveChanges() > 0;
            return success;
        }

        public bool UpdateCategory(Product product)
        {
            Product existingProduct = _applicationDbContext.Products.FirstOrDefault(x => x.Id == product.Id);

            if (existingProduct != null)
            {
                if (product.Image == null)
                {
                    product.Image = existingProduct.Image;
                }
                _applicationDbContext.Products.Update(product);
                _applicationDbContext.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool DeleteCategory(Product product)
        {
            Product existingProduct = _applicationDbContext.Products.FirstOrDefault(x => x.Id == product.Id);

            if (existingProduct != null)
            {
                _applicationDbContext.Products.Remove(existingProduct);
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