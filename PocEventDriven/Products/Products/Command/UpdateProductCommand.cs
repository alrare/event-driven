using MediatR;
using Products.Models;

namespace Products.Application.Commands;

/// <summary>
/// UpdateProductCommand
/// </summary>
/// <param name="Product"></param>
/// <returns></returns>
public record UpdateProductCommand(Product Product) : IRequest<Product>; //Utilizar DTO
