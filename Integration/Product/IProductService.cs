using Integration.Model.ProductModels;

namespace Integration.ProductServices
{
    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(Guid productId);
        Task CreateDummyProductsAsync();
    }
}
