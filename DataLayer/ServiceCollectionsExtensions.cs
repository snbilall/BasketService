using Core.Model;
using DataLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddDataLayers(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoConnectionOptions>(options =>
            {
                options.ConnectionString = configuration.GetSection("ConnectionString").Value;
                options.DatabaseName = configuration.GetSection("BasketDb").Value;
            });
            services.AddSingleton<MongoDbContext>();
        }
    }
}
