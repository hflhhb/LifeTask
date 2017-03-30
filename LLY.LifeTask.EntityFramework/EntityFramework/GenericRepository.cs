using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LLY.LifeTask.Repository.Infra;
using Microsoft.EntityFrameworkCore;

namespace LLY.LifeTask.EntityFramework
{
    public class GenericRepository<T, TContext> : /*RepositoryBase<T>,*/ IRepository<T>
        where T : class
        where TContext : DbContext, IDisposable
    {
        private readonly DbSet<T> _dbset;
        private TContext _dataContext;

        protected GenericRepository(IDataContextFactory<TContext> dataContextFactory)
        {
            DataContextFactory = dataContextFactory;
            _dbset = DataContext.Set<T>();
        }

        protected IDataContextFactory<TContext> DataContextFactory { get; private set; }

        protected TContext DataContext
        {
            get { return _dataContext ?? (_dataContext = DataContextFactory.GetContext()); }
        }

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Add(IEnumerable<T> entities)
        {
            _dbset.AttachRange(entities);
        }

        public virtual T Update(T entity)
        {
            //_dbset.Attach(entity);
            //_dataContext.Entry(entity).State = EntityState.Modified;
           return _dbset.Update(entity).Entity;
        }

        public virtual void Update<TEntity>(TEntity entity) where TEntity : class
        {
            //var entitySet = DataContext.Set<TEntity>();
            _dataContext.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual T Update(long id, Action<T> updateAction)
        {
            var entity = GetById(id);
            updateAction(entity);
            // Update(entity);
            return entity;
        }

        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var delEntities = _dbset.Where(@where).AsEnumerable();
            _dbset.RemoveRange(delEntities);

            //var objects = _dbset.Where(@where).AsEnumerable();
            //foreach (var obj in objects)
            //    _dbset.Remove(obj);
        }

        public virtual void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _dataContext.Remove(entity);
        }

        public virtual void Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _dataContext.RemoveRange(entities);
        }

        public virtual void Delete<TEntity>(Expression<Func<TEntity, bool>> where) where TEntity : class
        {
            var entitySet = DataContext.Set<TEntity>();
            var delEntities = entitySet.Where(@where).AsEnumerable();
            _dataContext.RemoveRange(delEntities);
        }


        public virtual void Delete(long id)
        {
            var entity = GetById(id);
            if (entity != null) _dbset.Remove(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbset;
        }
        public virtual IEnumerable<T> GetAllList()
        {
            return _dbset.ToList();
        }
        public async Task<IEnumerable<T>> GetAllListAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllListAsync(Expression<Func<T, bool>> predicate)
        {
            return await GetAll().Where(predicate).ToListAsync();
        }

        public T Get(long id)
        {
            var entity = GetAll().FirstOrDefault(CreateEqualityExpressionForId<T>(id));
            return entity;
        }

        public async Task<T> GetAsync(long id)
        {
            var entity = await FirstOrDefaultAsync(id);
            return entity;
        }

        public async Task<T> SingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await GetAll().SingleAsync(predicate);
        }

        public virtual T GetById(long id)
        {
            return GetAll().FirstOrDefault(CreateEqualityExpressionForId<T>(id));
        }
        public virtual TEntity GetById<TEntity>(long id) where TEntity : class
        {
            var entitySet = DataContext.Set<TEntity>();
            return entitySet.FirstOrDefault(CreateEqualityExpressionForId<TEntity>(id));
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await FirstOrDefaultAsync(id);
        }
        public virtual async Task<TEntity> GetByIdAsync<TEntity>(long id) where TEntity : class
        {
            var entitySet = DataContext.Set<TEntity>();
            return await entitySet.FirstOrDefaultAsync(CreateEqualityExpressionForId<TEntity>(id));
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = _dbset.Where(predicate);
            return query;
        }

        public virtual IQueryable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : class
        {
            var entitySet = DataContext.Set<TEntity>();
            IQueryable<TEntity> query = entitySet;
            if (predicate != null)
            {
                query = entitySet.Where(predicate);
            }
            return query;
        }

        //
        public virtual int Save()
        {
            return _dataContext.SaveChanges();
        }
        public virtual async Task<int> SaveAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }

        public virtual void BatchAdd(IEnumerable<T> entities)
        {
            _dbset.AddRange(entities);
        }
        public virtual void BatchAdd<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            var entitySet = DataContext.Set<TEntity>();
            entitySet.AddRange(entities);
        }

        #region 执行原生的SQL（不推荐）

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _dataContext.Database.ExecuteSqlCommand(sql, parameters);
        }

        //public IEnumerable SqlQuery(Type elementType, string sql, params object[] parameters)
        //{
        //    return _dataContext.Database.SqlQuery(elementType, sql, parameters);
        //}

        public IEnumerable<T> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return _dbset.FromSql<T>(sql, parameters);
        }
        #endregion

        #region Async

        public virtual async Task<T> FirstOrDefaultAsync(long id)
        {
            var where = CreateEqualityExpressionForId<T>(id);
            return await GetAll().FirstOrDefaultAsync(where);
          
        }
        protected Expression<Func<TEntity, bool>> CreateEqualityExpressionForId<TEntity>(long id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(long))
                );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await GetAll().FirstOrDefaultAsync(predicate);
        }

        //public virtual Task<T> UpdateAsync(T entity)
        //{
        //    return Task.FromResult(Update(entity));
        //}
        public virtual async Task<T> UpdateAsync(long id, Func<T, Task> updateAction)
        {
            var entity = await GetAsync(id);
            await updateAction(entity);
            return entity;
        }
//#pragma warning disable 1998
//        //因为我们在service层是SaveChangesAsync提交的，所以这里并不需要await
//        public virtual async Task DeleteAsync(T entity)
//        {
//            Delete(entity);
//        }

//        public virtual async Task DeleteAsync(long id)
//        {
//            Delete(id);
//        }
//#pragma warning restore 1998
        ///// <summary>
        ///// 使用扩展删除，只生成一条Sql语句
        ///// </summary>
        ///// <param name="predicate"></param>
        ///// <returns></returns>
        //public virtual async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        //{
        //    //await GetAll().Where(predicate).DeleteAsync();
        //}

        //public virtual Task<T> InsertAsync(T entity)
        //{
        //    //return Task.FromResult(_dbset.Add(entity));
        //}

        #endregion
    }
}