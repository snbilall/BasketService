using Integration.Model.ElasticModels;

namespace Integration.Model.ProductModels
{
    public class Product : BaseIntegrationModel
    {
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
