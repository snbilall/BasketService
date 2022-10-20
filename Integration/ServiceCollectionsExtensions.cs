using Core.Model;
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
            services.Configure<ElasticConnectionOptions>(options =>
            {
                options.Host = configuration.GetSection("ElasticHost").Value;
                options.Port = configuration.GetSection("ElasticPort").Value;
            });
            services.AddSingleton<IElasticService, ElasticService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
