using MediatR;
using FirstApi.Model;
using System;

namespace FirstApi.CQRS.Commands
{
    public class DeleteProductByIdCommand : IRequest<Product?>
    {
        public long id { get; set; }
    }
}






   