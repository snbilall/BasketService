using MongoDB.Driver;

namespace DataLayer
{
    public interface IMongoDbContext
    {
        IMongoDatabase MongoDatabase { get; }
    }
}
