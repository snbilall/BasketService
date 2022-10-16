using Core.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace DataLayer
{
    public class MongoDbContext : IMongoDbContext
    {
        public readonly IMongoDatabase mongoDatabase;
        public MongoDbContext(IOptions<MongoConnectionOptions> options)
        {
            MongoClient mongoClient = new MongoClient(options.Value.ConnectionString);
            mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoDatabase MongoDatabase => mongoDatabase;
    }
}
