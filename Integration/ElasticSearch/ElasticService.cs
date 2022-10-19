using Core.Model;
using Integration.Model.ElasticModels;
using Integration.ProductServices;
using Microsoft.Extensions.Options;
using Nest;

namespace Integration.ElasticSearch
{
    public class ElasticService : IElasticService
    {
        private readonly ElasticClient _client;
        public ElasticService(IOptions<ElasticConnectionOptions> options)
        {
            string host = "http://host.docker.internal";
            string port = "9200";
            var settings = new ConnectionSettings(new Uri(host + ":" + port));
            settings.EnableApiVersioningHeader();

            _client = new ElasticClient(settings);
        }

        public async Task CheckIndex<T>(Func<CreateIndexDescriptor, CreateIndexDescriptor> func)
            where T : BaseIntegrationModel
        {
            var indexName = typeof(T).Name.ToLower();
            var any = await _client.Indices.ExistsAsync(indexName);
            if (any.Exists)
                return;

            var func1 = func;
            var response = await _client.Indices.CreateAsync(indexName,
                ci =>
                {
                    ci
                    .Index(indexName)
                    .Settings(s => s.NumberOfShards(3).NumberOfReplicas(1));
                    ci = func(ci);
                    return ci;
                });

            return;
        }

        public async Task InsertBulkDocuments<T>(List<T> entities)
            where T : BaseIntegrationModel
        {
            var indexName = typeof(T).Name.ToLower();
            await _client.IndexManyAsync(entities, index: indexName);
        }

        public async Task InsertDocument<T>(T entity)
            where T : BaseIntegrationModel
        {
            var indexName = typeof(T).Name.ToLower();
            var response = await _client.CreateAsync(entity, q => q.Index(indexName));
            if (response.ApiCall?.HttpStatusCode == 409)
            {
                await _client.UpdateAsync<T>(entity.Id, a => a.Index(indexName).Doc(entity));
            }
        }

        public async Task<List<T>> GetDocuments<T>(Func<QueryContainerDescriptor<T>, QueryContainer> query)
            where T : BaseIntegrationModel
        {
            var indexName = typeof(T).Name.ToLower();
            var response = await _client.SearchAsync<T>(s => s.Index(indexName)
                                                              .Query(query));
            return response.Documents.ToList();
        }

        public async Task<T> GetDocument<T>(string id)
            where T : BaseIntegrationModel
        {
            var indexName = typeof(T).Name.ToLower();
            var response = await _client.GetAsync<T>(id, q => q.Index(indexName));
            return response.Source;
        }

    }
}
