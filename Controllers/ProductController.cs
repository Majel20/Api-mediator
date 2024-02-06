using Microsoft.AspNetCore.Mvc;
using FirstApi.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using FirstApi.CQRS.Commands;
using Newtonsoft.Json;
using FirstApi.Model;
using FirstApi.CQRS.Queries;
using System.Reflection.Metadata.Ecma335;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator) {
            _mediator = mediator;
                }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductCommand productCommand)
        {
            var products = await _mediator.Send(productCommand);
            return Ok(products);
        }


        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var products = await _mediator.Send(new GetProductQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(long id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery() { Id = id });
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductById(DeleteProductByIdCommand deleteProductByIdCommand)
        {
            await _mediator.Send(deleteProductByIdCommand);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(UpdateProductCommand product)
        {
            var producting = await _mediator.Send(product);
            return Ok(producting);
        }

    }
}
