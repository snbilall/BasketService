﻿using Core.Model;
using DataLayer.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddDataLayers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoDbContext, MongoDbContext>();
            services.AddScoped<IBasketRepository, BasketRepository>();
        }
    }
}
