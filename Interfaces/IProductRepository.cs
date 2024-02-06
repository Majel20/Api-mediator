using FirstApi.Model;
using FirstApi.Repository;
using System;

namespace FirstApi.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product> {
        Task<Product> CreateProduct(Product product);
        Task<Product?> GetProductById(long id);
        Task<Product> UpdateProduct(Product product);
        Task<Product?> DeleteProduct(Product product);

    }
}
