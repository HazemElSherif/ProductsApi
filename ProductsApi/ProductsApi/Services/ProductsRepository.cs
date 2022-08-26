using ProductsApi.DbContexts;
using ProductsApi.Entities;
using ProductsApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductsApi.Services
{
    public class ProductsRepository : IProductsRepository
    {
        ProductsContext dbContext;

        public ProductsRepository(ProductsContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public RepositoryResult<IEnumerable<Product>> GetProducts(int? categoryID)
        {
            var result = new RepositoryResult<IEnumerable<Product>>();
            result.Success = true;

            if (categoryID != null)
            {
                result.Results = dbContext.Products.Where(x => x.CategoryID == categoryID);
                return result;
            }

            result.Results = dbContext.Products;

            return result;
        }

        public RepositoryResult<Product> GetProductById(int productId)
        {
            var result = new RepositoryResult<Product>();

            var product = dbContext.Products.Where(x => x.ID == productId).SingleOrDefault();

            if (product == null)
            {
                result.Messages.Add("Product is not found");

                return result;
            }

            result.Success = true;
            result.Result = product;

            return result;
        }

        public RepositoryResult<Product> CreateProduct(Product product)
        {
            var result = new RepositoryResult<Product>();

            var isCategoryExists = dbContext.Categories.Where(x => x.ID == product.CategoryID).Any();

            if (isCategoryExists)
            {
                dbContext.Products.Add(product);
                dbContext.SaveChanges();

                result.Success = true;
                result.Result = product;

                return result;
            }

            result.Messages.Add("CategoryID is invalid");

            return result;
        }

        public RepositoryResult<Product> UpdateProduct(Product product)
        {
            var result = new RepositoryResult<Product>();

            var isCategoryExists = dbContext.Categories.Where(x => x.ID == product.CategoryID).Any();
            var isProductExists = dbContext.Products.Where(x => x.ID == product.ID).Any();

            if (isCategoryExists && isProductExists)
            {
                dbContext.Products.Update(product);
                dbContext.SaveChanges();

                result.Success = true;
                result.Result = product;

                return result;
            }

            if (!isCategoryExists)
            {
                result.Messages.Add("CategoryID is invalid");
            }

            if (!isProductExists)
            {
                result.Messages.Add("ProductID is invalid");
            }

            return result;
        }
    }
}
