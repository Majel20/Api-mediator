using System;

using MediatR;
using FirstApi.Model;

namespace FirstApi.CQRS.Queries
{
    public class GetProductQuery : IRequest<List<Product>>
    {
        IEnumerable<Product> product;
    }
}
