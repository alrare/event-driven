using MediatR;
using Products.Models;
using Products.Data;


namespace Products.Application.Commands.Handlers;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Product>
{
    private readonly DataContext _context;

    public DeleteProductHandler(DataContext context)
    {
        _context = context;
    }

    /// <summary>
    /// DeleteProductHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        _context.Products.Remove(request.Product);

        await _context.SaveChangesAsync();

        return request.Product;
    }
}
