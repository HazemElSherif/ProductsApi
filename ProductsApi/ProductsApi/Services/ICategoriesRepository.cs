using ProductsApi.Entities;
using ProductsApi.Models;
using System.Collections.Generic;

namespace ProductsApi.Services
{
    public interface ICategoriesRepository
    {
        public RepositoryResult<IEnumerable<Category>> GetCategories();
    }
}
