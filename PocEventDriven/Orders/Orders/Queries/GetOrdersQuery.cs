using MediatR;
using Orders.Models;
using Orders.DTO;

namespace Orders.Queries;

/// <summary>
/// GetOrdersQuery
/// </summary>
/// <returns></returns>

//public record GetOrdersQuery() : IRequest<IEnumerable<Order>>;


public record GetOrdersQuery() : IRequest<IEnumerable<OrderDto>>;