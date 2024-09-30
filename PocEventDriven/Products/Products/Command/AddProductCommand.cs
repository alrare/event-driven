using MediatR;
using Products.Models;

namespace Products.Application.Commands;

/// <summary>
/// AddProductCommand
/// </summary>
/// <param name="Product"></param>
/// <returns></returns>
public record AddProductCommand(Product Product) : IRequest<Product>;  //Utilizar DTO
