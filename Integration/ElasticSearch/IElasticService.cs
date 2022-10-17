using Integration.Model.ElasticModels;
using Nest;

namespace Integration.ElasticSearch
{
    public interface IElasticService
    {
        Task CheckIndex<T>()
            where T : BaseIntegrationModel;
        Task InsertDocument<T>(T entity)
            where T : BaseIntegrationModel;
        Task InsertBulkDocuments<T>(List<T> entities)
            where T : BaseIntegrationModel;
        Task<T> GetDocument<T>(string id) 
            where T : BaseIntegrationModel;
        Task<List<T>> GetDocuments<T>(Func<QueryContainerDescriptor<T>, QueryContainer> query)
            where T : BaseIntegrationModel;
    }
}
