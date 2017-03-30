using System;

namespace LLY.LifeTask.EntityFramework
{
    public interface IDataContextFactory<out TContext> : IDisposable where TContext : IDisposable
    {
        TContext GetContext();
    }
}