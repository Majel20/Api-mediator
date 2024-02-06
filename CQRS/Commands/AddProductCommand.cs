using FirstApi.Model;
using MediatR;
using System;
namespace FirstApi.CQRS.Commands
{
    public class AddProductCommand : IRequest<Product>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
