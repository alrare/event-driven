using MediatR;
using Orders.Models;


namespace Orders.Services.External
{
    public record ProductCreatedConsumer(ProductCopy ProductCopy) : IRequest<ProductCopy>;  //Utilizar DTO
}
