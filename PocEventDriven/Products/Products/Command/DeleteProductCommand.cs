using MediatR;
using Products.Models;

namespace Products.Application.Commands;

/// <summary>
/// DeleteProductCommand
/// </summary>
/// <param name="Product"></param>
/// <returns></returns>
public record DeleteProductCommand(Product Product) : IRequest<Product>; //Utilizar DTO
