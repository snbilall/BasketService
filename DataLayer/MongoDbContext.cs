using Core.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataLayer
{
    public class MongoDbContext : IMongoDbContext
    {
        public readonly IMongoDatabase mongoDatabase;
        protected MongoDbContext(IOptions<MongoConnectionOptions> options)
        {
            MongoClient mongoClient = new MongoClient(options.Value.ConnectionString);
            mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoDatabase MongoDatabase => mongoDatabase;
    }
}
