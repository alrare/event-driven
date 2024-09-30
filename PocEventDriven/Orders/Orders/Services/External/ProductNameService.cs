using Microsoft.Extensions.Caching.Distributed;
using Orders.Data.External;
//using Products.Dto;

namespace Orders.Services.External
{
    public interface IProductNameService
    {
        //Obtener el nombre producto
        Task<string> GetProductName(int id, CancellationToken cancellationToken = default(CancellationToken));
        
        //Asignar el nombre producto
        Task SetProductName(int id, string name, CancellationToken cancellationToken = default(CancellationToken));
    }

    //TODO: #25
    public class ProductNameService : IProductNameService
    {
        private readonly IProductRepository _productRepository;  //Guarda la informacion obtenida 
        private readonly IDistributedCache _cache;               //Guarda valor nuevo en cache   
        private readonly IHttpClientFactory _httpClientFactory;  //Llama servicio externo producto 


        public ProductNameService(IProductRepository productRepository, IDistributedCache cache,
            IHttpClientFactory httpClientFactory)
        {
            _productRepository = productRepository;
            _cache = cache;
            _httpClientFactory = httpClientFactory;
        }


        public async Task<string> GetProductName(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            //Obtiene de la cache el nombre producto si existe 
            string value = await _cache.GetStringAsync($"ORDERS-PRODUCT::{id}", cancellationToken);
            if (value != null)
            {
                return value;
            }
            //string productName = await RetrieveProductName(id, cancellationToken);

            //return productName
            return "ProductName";
        }


        //Asigna el nombre del producto a la cache
        public async Task SetProductName(int id, string name,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await _productRepository.UpsertProductName(id, name, cancellationToken);
            await _cache.RemoveAsync($"ORDERS-PRODUCT::{id}", cancellationToken);
            await _cache.SetStringAsync($"ORDERS-PRODUCT::{id}", name, cancellationToken);
        }


        //private async Task<string> RetrieveProductName(int id, CancellationToken cancellationToken)
        //{
        //    //Obtiene product name de la base si existe 
        //    string? productName = await _productRepository.GetProductName(id, cancellationToken);

        //    if (productName == null)
        //    {
        //        //Llamada a la api para obtener valor
        //        FullProductResponse product = await GetProduct(id, cancellationToken);
        //        await SetProductName(id, product.Name, cancellationToken);
        //        productName = product.Name;
        //    }

        //    return productName;
        //}

        //private async Task<FullProductResponse> GetProduct(int productId, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    //Aqui se hace la llamada a la API


        //    //Convierte en Json




        //    ////TODO: abstract out all the HTTP calls to other distribt microservices #26
        //    //HttpClient client = _httpClientFactory.CreateClient();
        //    //string productsReadApi =
        //    //    await _discovery.GetFullAddress(DiscoveryServices.Microservices.ProductsApi.ApiRead, cancellationToken);
        //    //client.BaseAddress = new Uri(productsReadApi);

        //    ////TODO: replace exception
        //    //return await client.GetFromJsonAsync<FullProductResponse>($"product/{productId}", cancellationToken) ??
        //    //       throw new ArgumentException("Product does not exist");

        //    FullProductResponse product = new FullProductResponse(1, "NameProductDto", "DescriptionProductDto");

        //    return product;
        //}
    }
}
