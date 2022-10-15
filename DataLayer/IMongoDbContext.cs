using MongoDB.Driver;

namespace DataLayer
{
    internal interface IMongoDbContext
    {
        IMongoDatabase MongoDatabase { get; }
    }
}
