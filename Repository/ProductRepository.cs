using Microsoft.EntityFrameworkCore;
using FirstApi.Interfaces;
using FirstApi.Model;
using System;

namespace FirstApi.Repository
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        protected readonly ProductContext productContext;
        public ProductRepository(ProductContext context) : base(context)
        {
            productContext = context;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            productContext.Add(product);
            await productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> GetProductById(long product_id)
        {
            return await productContext.ProductItems.SingleOrDefaultAsync(x => x.Id == product_id);
        }

        public async Task<Product> UpdateProduct(Product up_product)
        {
            productContext.Update(up_product);
            await productContext.SaveChangesAsync();
            return up_product;
        }


        public async Task<Product?> DeleteProduct(Product del_product)
        {
            productContext.ProductItems.Remove(del_product);
            await productContext.SaveChangesAsync();
            return del_product!;
        }
    }
}
