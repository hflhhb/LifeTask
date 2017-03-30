using System;
using System.Threading.Tasks;
using LLY.LifeTask.Repository.Infra;
using Microsoft.EntityFrameworkCore;

namespace LLY.LifeTask.EntityFramework
{
    public abstract class UnitOfWorkBase<TContext> : IUnitOfWork where TContext : DbContext ,IDisposable
    {
        private readonly IDataContextFactory<TContext> _dataContextFactory;
        private TContext _dataContext;

        protected UnitOfWorkBase(IDataContextFactory<TContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        protected TContext DataContext
        {
            get { return _dataContext ?? (_dataContext = _dataContextFactory.GetContext()); }
        }

        #region IUnitOfWork Members

        public virtual void Commit()
        {
            if (DataContext != null)
            {
                DataContext.SaveChanges();
            }
        }

        public virtual async Task CommitAsync()
        {
            if (DataContext != null)
            {
                await DataContext.SaveChangesAsync();
            }
        }

        #endregion
    }
}