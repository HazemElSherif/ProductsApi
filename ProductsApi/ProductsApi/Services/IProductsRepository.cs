using ProductsApi.Entities;
using ProductsApi.Models;
using System.Collections.Generic;

namespace ProductsApi.Services
{
    public interface IProductsRepository
    {
        public RepositoryResult<IEnumerable<Product>> GetProducts(int? categoryID);
        public RepositoryResult<Product> GetProductById(int productId);

        public RepositoryResult<Product> CreateProduct(Product product);

        public RepositoryResult<Product> UpdateProduct(Product product);
    }
}
