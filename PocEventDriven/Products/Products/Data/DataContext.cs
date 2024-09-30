using Products.Models;
using Microsoft.EntityFrameworkCore;

namespace Products.Data
{
    public class DataContext : DbContext
    {
        /// <summary>
        /// DataContext
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        /// <summary>
        /// DbSet Products
        /// </summary>
        /// <value></value>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// GetAllProducts
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await Task.FromResult(Products);
        }

        /// <summary>
        /// GetProductById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Product> GetProductById(int id)
        {
            return await Task.FromResult(Products.Single(p => p.Id == id));
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task AddProduct(Product product)
        {
            Products.Add(product);

            await Task.CompletedTask;
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task UpdateProduct(int id, Product product)
        {
            Products.Update(product);

            await Task.CompletedTask;
        }

        /// <summary>
        /// DeleteProduct
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task DeleteProduct(int id, Product product)
        {
            Products.Remove(product);

            await Task.CompletedTask;
        }

        ///// <summary>
        ///// EventOccured
        ///// </summary>
        ///// <param name="product"></param>
        ///// <param name="evt"></param>
        ///// <returns></returns>
        //public async Task EventOccured(Product product, string evt)
        //{
        //    Products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";
        //    await Task.CompletedTask;
        //}
    }
}
