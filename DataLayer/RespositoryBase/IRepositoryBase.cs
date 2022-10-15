using Model.Base;
using System.Linq.Expressions;

namespace DataLayer.RespositoryBase
{
    public interface IRepositoryBase<T> : IDisposable
        where T : BaseEntity
    {
        IQueryable<T> Query();
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
