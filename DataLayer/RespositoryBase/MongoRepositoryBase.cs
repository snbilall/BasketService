using Model.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace DataLayer.RespositoryBase
{
    public class MongoRepositoryBase<TContext, T> : IRepositoryBase<T>
        where TContext : IMongoDbContext
        where T : BaseEntity
    {
        private IMongoCollection<T> Collection { get; }

        public MongoRepositoryBase(TContext context)
        {
            Collection = context.MongoDatabase.GetCollection<T>(typeof(T).Name);
        }

        public IQueryable<T> Query()
        {
            return Collection.AsQueryable();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return Collection.Find(predicate).FirstOrDefaultAsync();
        }

        public Task<T> GetByIdAsync(ObjectId id)
        {
            return Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task AddAsync(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            var options = new InsertOneOptions { BypassDocumentValidation = true };
            return Collection.InsertOneAsync(entity, options);
        }

        public Task<T> DeleteAsync(ObjectId id)
        {
            return Collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public Task<T> UpdateAsync(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            return Collection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
