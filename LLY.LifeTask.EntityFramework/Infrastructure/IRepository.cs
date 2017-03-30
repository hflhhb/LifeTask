using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LLY.LifeTask.Repository.Infra
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Add(IEnumerable<T> entities);
        void BatchAdd(IEnumerable<T> entities);
        void BatchAdd<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void Delete(long id);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        void Delete(Expression<Func<T, bool>> where);
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void Delete<TEntity>(Expression<Func<TEntity, bool>> where) where TEntity : class;
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : class;
        Task<T> FirstOrDefaultAsync(long id);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        T Get(long id);
        IQueryable<T> GetAll();
        IEnumerable<T> GetAllList();
        Task<IEnumerable<T>> GetAllListAsync();
        Task<IEnumerable<T>> GetAllListAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(long id);
        T GetById(long id);
        TEntity GetById<TEntity>(long id) where TEntity : class;
        Task<T> GetByIdAsync(long id);
        Task<TEntity> GetByIdAsync<TEntity>(long id) where TEntity : class;
        int Save();
        Task<int> SaveAsync();
        Task<T> SingleAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> SqlQuery<TElement>(string sql, params object[] parameters);
        T Update(T entity);
        T Update(long id, Action<T> updateAction);
        void Update<TEntity>(TEntity entity) where TEntity : class;
        Task<T> UpdateAsync(long id, Func<T, Task> updateAction);
    }
}