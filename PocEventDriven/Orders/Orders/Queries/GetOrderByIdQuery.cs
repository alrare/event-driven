using MediatR;
using Orders.Models;

namespace Orders.Queries;

/// <summary>
/// GetProductByIdQuery
/// </summary>
/// <param name="Id"></param>
/// <returns></returns>
public record GetOrderByIdQuery(int Id) : IRequest<Order>;
