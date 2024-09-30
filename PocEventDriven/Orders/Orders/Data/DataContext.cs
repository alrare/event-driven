using Microsoft.EntityFrameworkCore;
//using Products.Models;
using Product = Orders.Models.ProductCopy;
using Orders.Models;


namespace Orders.Data
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
        ///  DbSet ProductsCopy
        /// </summary>
        public DbSet<ProductCopy> ProductsCopy { get; set; }

        /// <summary>
        /// DbSet Orders
        /// </summary>
        /// <value></value>
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.ProductCopy)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.IdProduct);
        }

        /// <summary>
        /// GetAllOrders
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await Task.FromResult(Orders);
        }

        /// <summary>
        /// GetOrderById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Order> GetOrderById(int id)
        {
            return await Task.FromResult(Orders.Single(p => p.Id == id));
        }

        /// <summary>
        /// AddOrder
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task AddOrder(Order order)
        {
            Orders.Add(order);

            await Task.CompletedTask;
        }

        /// <summary>
        /// UpdateOrder
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task UpdateOrder(int id, Order order)
        {
            Orders.Update(order);

            await Task.CompletedTask;
        }

        /// <summary>
        /// DeleteOrder
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task DeleteOrder(int id, Order order)
        {
            Orders.Remove(order);

            await Task.CompletedTask;
        }

        /// <summary>
        /// EventOccured
        /// </summary>
        /// <param name="order"></param>
        /// <param name="evt"></param>
        /// <returns></returns>
        /* public async Task EventOccured(Order order, string evt)
        {
            Orders.Single(o => o.Id == order.Id).Id = $"{order.Id} evt: {evt}";
            await Task.CompletedTask;
        } */
    }
}