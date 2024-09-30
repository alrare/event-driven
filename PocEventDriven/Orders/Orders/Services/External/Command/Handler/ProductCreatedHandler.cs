using Orders.Data;
using Orders.Models;

namespace Orders.Services.External.Command.Handler
{
    public class ProductCreatedService
    {
        private readonly DataContext _context;

        public ProductCreatedService(DataContext context)
        {
            _context = context;
        }

        public async Task<ProductCopy> Handle(ProductCreatedConsumer request, CancellationToken cancellationToken)
        {
            _context.ProductsCopy.Add(request.ProductCopy);
            await _context.SaveChangesAsync();

            return request.ProductCopy;
        }
    }
}
