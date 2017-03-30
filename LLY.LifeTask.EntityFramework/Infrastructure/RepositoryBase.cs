using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace LLY.LifeTask.Repository.Infra
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : class
    {
        public abstract void Add(IEnumerable<T> entities);
        public abstract void Add(T entity);
        public abstract void BatchAdd(IEnumerable<T> entities);
        public abstract void BatchAdd<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        public abstract void Delete(IEnumerable<T> entities);
        public abstract void Delete(Expression<Func<T, bool>> where);
        public abstract void Delete(T entity);
        public abstract void Delete(long id);
        public abstract void Delete<TEntity>(Expression<Func<TEntity, bool>> where) where TEntity : class;
        public abstract void Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        public abstract void Delete<TEntity>(TEntity entity) where TEntity : class;
        public abstract IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        public abstract IQueryable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : class;
        public abstract Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        public abstract Task<T> FirstOrDefaultAsync(long id);
        public abstract T Get(long id);
        public abstract IQueryable<T> GetAll();
        public abstract IEnumerable<T> GetAllList();
        public abstract Task<IEnumerable<T>> GetAllListAsync();
        public abstract Task<IEnumerable<T>> GetAllListAsync(Expression<Func<T, bool>> predicate);
        public abstract Task<T> GetAsync(long id);
        public abstract T GetById(long id);
        public abstract TEntity GetById<TEntity>(long id) where TEntity : class;
        public abstract Task<T> GetByIdAsync(long id);
        public abstract Task<TEntity> GetByIdAsync<TEntity>(long id) where TEntity : class;
        public abstract int Save();
        public abstract Task<int> SaveAsync();
        public abstract Task<T> SingleAsync(Expression<Func<T, bool>> predicate);
        public abstract IEnumerable<T> SqlQuery<TElement>(string sql, params object[] parameters);
        public abstract T Update(T entity);
        public abstract T Update(long id, Action<T> updateAction);
        public abstract void Update<TEntity>(TEntity entity) where TEntity : class;
        public abstract Task<T> UpdateAsync(long id, Func<T, Task> updateAction);
    }
}