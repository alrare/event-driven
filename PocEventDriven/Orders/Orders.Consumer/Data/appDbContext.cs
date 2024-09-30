using Microsoft.EntityFrameworkCore;
using Orders.Consumer.Models;

namespace Orders.Consumer
{
    public class appDbContext : DbContext
    {

        public appDbContext(DbContextOptions<appDbContext> options) : base(options) { }

        public DbSet<ProductCopy> ProductsCopy { get; set; }


        public async Task AddProduct(ProductCopy productCopy)
        {
            ProductsCopy.Add(productCopy);

            await Task.CompletedTask;
        }


        public async Task UpdateOrder(int id, ProductCopy productCopy)
        {
            ProductsCopy.Update(productCopy);

            await Task.CompletedTask;
        }
    }
}