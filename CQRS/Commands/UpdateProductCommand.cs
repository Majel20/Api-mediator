using MediatR;
using FirstApi.Model;
using System;

namespace FirstApi.CQRS.Commands
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}



