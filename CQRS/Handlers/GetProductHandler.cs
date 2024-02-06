using MediatR;
using Microsoft.EntityFrameworkCore;
using FirstApi.Interfaces;
using FirstApi.Model;
using FirstApi.CQRS.Queries;
using System;


namespace FirstApi.CQRS.Handlers
{ 
    public class GetProductHandler : IRequestHandler<GetProductQuery, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductHandler(IProductRepository productRepository) {
            _productRepository = productRepository;
        }
        public Task<List<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return _productRepository.GetAll().ToListAsync();
        }
    }
}
