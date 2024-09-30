using MediatR;
using Products.Application.Queries;
using Products.Data;
using Products.Models;

namespace Products.Queries.Handlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly DataContext _context;
    public GetProductByIdHandler(DataContext context)
    {
        _context = context;
    }

    /// <summary>
    /// GetProductByIdHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
        await _context.GetProductById(request.Id);
}
