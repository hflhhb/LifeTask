using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LLY.LifeTask.EntityFramework
{
    public class GenericUnitOfWork<TContext> : UnitOfWorkBase<TContext> where TContext : DbContext, IDisposable, new()
    {
        public GenericUnitOfWork(IDataContextFactory<TContext> databaseFactory)
            : base(databaseFactory)
        {

        }

        public override void Commit()
        {
            if (DataContext != null)
            {
                DataContext.SaveChanges();
            }
        }

        public override async Task CommitAsync()
        {
            if (DataContext != null)
            {
                await DataContext.SaveChangesAsync();
            }
        }
    }
}
