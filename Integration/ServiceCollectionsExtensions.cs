using Integration.ElasticSearch;
using Integration.ProductServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Integration
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddIntegrationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IElasticService, ElasticService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
