using MediatR;
using Orders.Data;
using Orders.Models;
using Orders.Queries;

namespace Orders.Queries.Handlers;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order>
{
    private readonly DataContext _context;
    public GetOrderByIdHandler(DataContext context)
    {
        _context = context;
    }

    /// <summary>
    /// GetOrderByIdHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken) =>
        await _context.GetOrderById(request.Id);
}