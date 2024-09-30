using MediatR;
using Orders.Models;
using Orders.DTO;
using MassTransit.Initializers;
using Microsoft.EntityFrameworkCore;
using Orders.Data;
using Orders.Queries;

namespace Orders.Queries.Handlers;

//public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>

public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderDto>>
{
    private readonly DataContext _context;
    public GetOrdersHandler(DataContext context)
    {
        _context = context;
    }

    /// <summary>
    /// GetOrdersHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>

    //public async Task<IEnumerable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    //{
    //    return await _context.GetAllOrders();

    //}

    public async Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {

        var orders = await _context.Orders
        .Include(o => o.ProductCopy) // Incluimos la relación del producto
        .ToListAsync(cancellationToken);

        // Convertimos de Model a DTO
        var orderDtos = orders.Select(o => new OrderDto
        {
            Id = o.Id,
            IdProduct = o.IdProduct,
            Description = o.ProductCopy.Description,
            Quantity = o.Quantity
        });

        return orderDtos;
    }

}