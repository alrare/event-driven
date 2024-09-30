namespace Orders.Data.External
{
    public interface IProductRepository
    {
        Task<string?> GetProductName(int id, CancellationToken cancellationToken = default(CancellationToken));

        Task<bool> UpsertProductName(int id, string name, CancellationToken cancellationToken = default(CancellationToken));
    }


    public class ProductRepository : IProductRepository
    {
        //Por inyección de dependencias obtener nombre producto

        public Task<string?> GetProductName(int id, CancellationToken cancellationToken = default)
        {
            //Obtener 
            throw new NotImplementedException();
        }

        public Task<bool> UpsertProductName(int id, string name, CancellationToken cancellationToken = default)
        {
            //Obtener 
            throw new NotImplementedException();
        }
    }
}
