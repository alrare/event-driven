using MediatR;
using Orders.Models;

namespace Orders.Commands;

/// <summary>
/// UpdateOrderCommand
/// </summary>
/// <param name="Order"></param>
/// <returns></returns>
public record UpdateOrderCommand(Order Order) : IRequest<Order>; //Utilizar DTO
