using Integration.ElasticSearch;
using Integration.Model.ProductModels;

namespace Integration.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IElasticService _elasticService;

        public ProductService(IElasticService elasticService)
        {
            _elasticService = elasticService;
        }

        public async Task CreateDummyProductsAsync()
        {
            await _elasticService.CheckIndex<Product>();

            List<Guid> productIds = new List<Guid> { 
                Guid.Parse("be667845-3f43-42bc-9b10-6e37a9650fc3"),
                Guid.Parse("d20b5364-4270-4a6f-9cfe-546313140d51")
            };
            List<Product> products = new List<Product>();
            products.Add(new Product
            {
                Id = productIds[0],
                ProductName = "Uzumlu Kek",
                Price = 14,
                Stock = 20
            });
            products.Add(new Product
            {
                Id = productIds[0],
                ProductName = "Elmali Pasta",
                Price = 30,
                Stock = 150
            });
            await _elasticService.InsertBulkDocuments(products);
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            return await _elasticService.GetDocument<Product>(productId.ToString());
        }
    }
}
