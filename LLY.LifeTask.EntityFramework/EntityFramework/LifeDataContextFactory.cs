using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LLY.LifeTask.Model;
using LLY.LifeTask.Model.EntityFramework;

namespace LLY.LifeTask.EntityFramework
{
    public interface ILifeDataContextFactory : IDataContextFactory<LifeDbContext>
    {

    }
    public class LifeDataContextFactory : GenericDataContextFactory<LifeDbContext>, ILifeDataContextFactory
    {
        public LifeDataContextFactory(LifeDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
