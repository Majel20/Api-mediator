using MediatR;
using Microsoft.EntityFrameworkCore;
using FirstApi.CQRS.Commands;
using FirstApi.Interfaces;
using FirstApi.Model;
using System;


namespace FirstApi.CQRS.Handlers
{
    public class UpdateProductHandler
    {

        private readonly IProductRepository _productRepository;
        private readonly ProductContext _productContext;

        public UpdateProductHandler(IProductRepository productRepository, ProductContext productContext)
        {
            _productRepository = productRepository;
            _productContext = productContext;
        }


        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _productContext.ProductItems.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (product == null)
            {
                throw new Exception("Record does not exist" + request.Id);
            }

            product.Name = request.Name;
            product.Description = request.Description;
            return await _productRepository.UpdateProduct(product);
        }
    }
}
