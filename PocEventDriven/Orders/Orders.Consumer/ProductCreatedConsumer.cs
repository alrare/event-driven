using MassTransit;
using Microsoft.EntityFrameworkCore;
using Orders.Models;
using Shared.Comminication;

namespace Orders.Consumer
{
    public class ProductCreatedConsumer : IConsumer<ProductCreated>
    {
        private readonly appDbContext _dbContext; 

        public ProductCreatedConsumer(appDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<ProductCreated> context)
        {
            var message = context.Message;

            // Crear una instancia del producto basado en el mensaje
            var productCopy = new ProductCopy
            {
                Id = message.Id,
                Name = message.Name,
                Description = message.Description
            };

            // Insertar en la tabla productsCopy
            _dbContext.Add(productCopy);
            await _dbContext.SaveChangesAsync();

            Console.WriteLine($"Producto {message.Name} insertado en la base de datos de órdenes.");
        }
    }
}
