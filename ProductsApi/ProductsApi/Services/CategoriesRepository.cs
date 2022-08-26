using ProductsApi.DbContexts;
using ProductsApi.Entities;
using ProductsApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductsApi.Services
{
    public class CategoriesRepository : ICategoriesRepository
    {
        ProductsContext dbContext;
        public CategoriesRepository(ProductsContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public RepositoryResult<IEnumerable<Category>> GetCategories()
        {
            var result = new RepositoryResult<IEnumerable<Category>>();

            var categories = dbContext.Categories.ToList();

            result.Success = true;
            result.Results = categories;

            return result;
        }
    }
}
