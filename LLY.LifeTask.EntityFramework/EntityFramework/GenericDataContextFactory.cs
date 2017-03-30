using System;
using Microsoft.EntityFrameworkCore;

namespace LLY.LifeTask.EntityFramework
{
    public class GenericDataContextFactory<TContext> : IDataContextFactory<TContext> where TContext : DbContext, IDisposable
    {
        private TContext _dataContext;

        #region IDatabaseFactory Members
        public GenericDataContextFactory(TContext dataContext)
        {
            _dataContext = dataContext;
        }
        public TContext GetContext()
        {
            return _dataContext;
        }

        #endregion

        public void Dispose()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}
