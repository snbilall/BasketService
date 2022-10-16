using Model.Base;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace DataLayer.RespositoryBase
{
    public interface IRepositoryBase<T> : IDisposable
        where T : BaseEntity
    {
        IQueryable<T> Query();
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(ObjectId id);
        Task AddAsync(T entity);
        Task<T> DeleteAsync(ObjectId id);
        Task<T> UpdateAsync(T entity);
    }
}
