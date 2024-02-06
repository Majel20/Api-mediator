using MediatR;
using FirstApi.Model;
using System;

namespace FirstApi.CQRS.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public long Id { get; set; }
    }
}
