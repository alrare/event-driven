using MediatR;
using Products.Application.Queries;
using Products.Data;
using Products.Models;

namespace Products.Queries.Handlers;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly DataContext _context;
    public GetProductsHandler(DataContext context)
    {
        _context = context;
    }

    /// <summary>
    /// GetProductsHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _context.GetAllProducts();
    }
}


