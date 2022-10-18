using Business.BasketProviders;
using Integration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIntegrationServices(configuration);
            services.AddScoped<IBasketProvider, BasketProvider>();
        }
    }
}