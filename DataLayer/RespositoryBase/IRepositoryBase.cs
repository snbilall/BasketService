using Model;
using Model.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataLayer.RespositoryBase
{
    public interface IRepositoryBase : IDisposable
    {
        Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, params Expression<Func<T, object>>[] includes) where T : BaseEntity;
        Task<T> FirstOrDefaultNoLockAsync<T>(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, params Expression<Func<T, object>>[] includes) where T : BaseEntity;
        Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : BaseEntity;
        Task<T> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : BaseEntity;
        Task<T> SingleOrDefaultNoLockAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : BaseEntity;
        int Count<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;
        int CountNoLock<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;
        Task ReloadAsync(BaseEntity entity);

        Task<int> CountAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;
        Task<int> CountNoLockAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;
        Task<List<T>> GetAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : BaseEntity;

        IQueryable<T> Query<T>() where T : BaseEntity;
        void Add<T>(params T[] entities) where T : BaseEntity;

        void Delete<T>(T entity) where T : BaseEntity;

        void Update<T>(T entity) where T : BaseEntity;

        Task<int> CommitAsync();
        int Commit();
    }
