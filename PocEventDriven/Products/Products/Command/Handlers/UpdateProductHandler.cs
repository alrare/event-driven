using MediatR;
using Microsoft.EntityFrameworkCore;

using MassTransit;
using Products.Data;
using Products.Models;

namespace Products.Application.Commands.Handlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
{
    private readonly DataContext _context;
    public readonly IPublishEndpoint _publishEndpoint;
    private readonly ISendEndpointProvider _sendEndpoint;

    public UpdateProductHandler(DataContext context, ISendEndpointProvider sendEndpoint, IPublishEndpoint publishEndpoint)
    {
        _context = context;
        _sendEndpoint = sendEndpoint;
        _publishEndpoint = publishEndpoint;

    }

    /// <summary>
    /// UpdateProductHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        _context.Products.Update(request.Product);

        await _context.SaveChangesAsync();

        if (_context is not null)
        {
            //await _publishEndpoint.Publish<Product>(_context);
            var endpoint = await _sendEndpoint.GetSendEndpoint(new Uri("rabbitmq://localhost/product-queue"));

             // Serializar a JSON
            //string jsonString = JsonConvert.SerializeObject(request.Product);
            //Console.WriteLine(jsonString);
            //await endpoint.Send(jsonString);

            await endpoint.Send(new Product { Id = 2, Name = "2 Update", Description = "Update 2 Description" });
        }

        return request.Product;
    }
}
