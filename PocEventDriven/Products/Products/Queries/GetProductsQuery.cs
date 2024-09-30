using MediatR;
using Products.Models;

namespace Products.Application.Queries;

/// <summary>
/// GetProductsQuery
/// </summary>
/// <returns></returns>
public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
