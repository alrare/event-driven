using MediatR;
using Orders.Models;

namespace Orders.Commands;

/// <summary>
/// AddOrderCommand
/// </summary>
/// <param name="Order"></param>
/// <returns></returns>
public record AddOrderCommand(Order Order) : IRequest<Order>;  //Utilizar DTO
