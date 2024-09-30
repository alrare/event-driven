using MediatR;
using MassTransit;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Commands;
using Products.Application.Queries;
using Products.Data;
using Products.Models;
using Shared.Comminication;
using MassTransit.Transports;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        //private readonly IPublisher _publisher;
        private readonly IPublishEndpoint _publishEndpoint;

        public ProductsController(ISender sender, IPublishEndpoint publishEndpoint)
        {
            _sender = sender;
            //_publisher = publisher;
            _publishEndpoint = publishEndpoint;
        }

        /// <summary>
        /// GetProducts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductsQuery());
            return Ok(products);
        }

        /// <summary>
        /// GetProductById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var prodToReturn = await _sender.Send(new AddProductCommand(product));

            //Publisher
            //await _publisher.Publish(new ProductAddedNotifications(productToReturn));

            //Pasar valores de Product a IProductCreated
            var prodCreated = MapToProductCreated(product);

            ProductCreated MapToProductCreated(Product product)
            {
                ProductCreated productCreated = new ProductCreated
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description
                };
                return productCreated;
            }

            Thread.Sleep(2000);

            //Publish masstransit
            await _publishEndpoint.Publish(prodCreated, cancellationToken:default);

            Thread.Sleep(2000);

            return CreatedAtRoute("GetProductById", new { id = product.Id }, prodToReturn);
        }


       

        /// <summary>
        /// UpdateProduct
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("Producto id no existe");
            }

            var response = await _sender.Send(new UpdateProductCommand(product));

            //Envío de mensaje a rabbitMQ
            //await _publishEndpoint.Publish(product);

            return Ok(response);
        }


        /// <summary>
        /// DeleteProduct
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("Producto id no existe");
            }

            var response = await _sender.Send(new DeleteProductCommand(product));

            return Ok(response);
        }
    }
}
