using MediatR;
using Orders.Models;

namespace Orders.Commands;

/// <summary>
/// DeleteOrderCommand
/// </summary>
/// <param name="Order"></param>
/// <returns></returns>
public record DeleteOrderCommand(Order Order) : IRequest<Order>; //Utilizar DTO
