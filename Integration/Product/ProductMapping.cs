using Integration.Model.ProductModels;
using Nest;

namespace Integration.ProductServices
{
    public static class ProductMapping
    {
        public static CreateIndexDescriptor ProductMap(this CreateIndexDescriptor descriptor)
        {
            return descriptor.Map<Product>(m => m.Properties(p => p
                .Keyword(k => k.Name(n => n.Id))
                .Text(t => t.Name(n => n.ProductName))
                .Number(t => t.Name(n => n.Price))
                .Number(t => t.Name(n => n.Stock))
            ));
        }
    }
}
