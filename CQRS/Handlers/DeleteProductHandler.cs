using MediatR;
using Microsoft.EntityFrameworkCore;
using FirstApi.CQRS.Commands;
using FirstApi.Interfaces;
using FirstApi.Model;
using static System.Console;
using System;

namespace FirstApi.CQRS.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductByIdCommand, Product?>
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductContext _productContext;

        public DeleteProductHandler(IProductRepository productRepository, ProductContext productContext)
        {
            _productRepository = _productRepository;
            _productContext = productContext;
        }

        public async Task<Product?> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            Product product = await _productContext.ProductItems.SingleOrDefaultAsync(x => x.Id == request.id);
            if (product == null)
            {
                throw new Exception("Record does not exist" + request.id);
            }

            return await _productRepository.DeleteProduct(product);
        }
    }
}
