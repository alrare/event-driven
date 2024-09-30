using Microsoft.AspNetCore.Mvc;
using Orders.Data;
using Orders.Models;
using Shared.Comminication;

namespace Orders.Services.External
{
    public class ProductCreatedService
    {
        private readonly DataContext _context;

        public ProductCreatedService(DataContext context)
        {
            _context = context;
        }

        public async Task<ProductCopy> AddProductService(ProductCopy productCopy)
        {
            _context.ProductsCopy.Add(productCopy);
            await _context.SaveChangesAsync();

            return productCopy;
        }
    }
}