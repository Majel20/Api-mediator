using MediatR;
using FirstApi.Interfaces;
using FirstApi.Model;
using FirstApi.CQRS.Queries;
using System;
using FirstApi.Repository;

namespace FirstApi.CQRS.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {

        private readonly IProductRepository _productRepository;
        private readonly ProductContext _productContext;

        public GetProductByIdHandler(IProductRepository productRepository, ProductContext productContext)
        {
            _productRepository = _productRepository;
            _productContext = productContext;
        }

        public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetProductById(request.Id);
            if (product != null)
            {
                return await product;

            }
            throw new Exception("Record does not exist" + request.Id);


        }
    }

}

