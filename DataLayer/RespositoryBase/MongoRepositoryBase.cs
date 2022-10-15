using Model.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataLayer.RespositoryBase
{
    internal abstract class MongoRepositoryBase<TContext, T> : IRepositoryBase<T>
        where TContext : IMongoDbContext
        where T : BaseEntity
    {
        private TContext context { get; set; }
        private IMongoCollection<T> Collection { get; }

        public MongoRepositoryBase(TContext context)
        {
            this.context = context;
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

        public Task<T> GetByIdAsync(Guid id)
        {
            return Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task AddAsync(T entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            return Collection.InsertOneAsync(entity, options);
        }

        public Task<T> DeleteAsync(T entity)
        {
            return Collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        public Task<T> UpdateAsync(T entity)
        {
            return Collection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
