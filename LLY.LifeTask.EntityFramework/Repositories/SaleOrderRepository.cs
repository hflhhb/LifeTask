using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LLY.LifeTask.Model;
using LLY.LifeTask.Model.Life;
using LLY.LifeTask.Model.EntityFramework;

namespace LLY.LifeTask.EntityFramework.Repositories
{
    public interface ISaleOrderRepository
    {
        IQueryable<SaleOrder> GetAllOrders();
    }

    public class SaleOrderRepository : GenericRepository<SaleOrder, LifeDbContext>, ISaleOrderRepository
    {
        public SaleOrderRepository(IDataContextFactory<LifeDbContext> dataContextFactory) :
            base(dataContextFactory)
        {

        }

        public IQueryable<SaleOrder> GetAllOrders()
        {
            return GetAll();
        }
    }
}
