
using FirstApi.CQRS.Commands;
using FirstApi.Interfaces;
using MediatR;
using FirstApi.Model;
using System;

namespace FirstApi.CQRS.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
    private readonly IProductRepository _productRepository;
    public AddProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken) {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
          //  Id = request.Id
        };
        return await _productRepository.CreateProduct(product);
    }
    }
}
