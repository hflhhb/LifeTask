using Dapper;
using LLY.LifeTask.Model.Life;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LLY.LifeTask.Dapper
{

    public interface ISaleOrderProvider
    {
        IEnumerable<SaleOrder> GetAllOrders();
        Task<IEnumerable<SaleOrder>> GetAllOrdersAsync();
    }

    public class SaleOrderProvider : ISaleOrderProvider
    {
        private readonly IDataProvider _dbFactory = null;

        public SaleOrderProvider(IDataProvider dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public IEnumerable<SaleOrder> GetAllOrders()
        {
            //using (var db = _dbFactory.Create())
            //{
            //    return db.Query<SaleOrder>("select * from SaleOrders");
            //    //return new List<SaleOrder>() { new SaleOrder() { OrderNo ="xyz" }, new SaleOrder() { OrderNo = "123" } };
            //}

            //return _dbFactory.Using(db => db.Query<SaleOrder>("select * from SaleOrders; --waitfor delay '00:00:10'"));
            return _dbFactory.Connection.Query<SaleOrder>("select * from SaleOrders");
        }
        public async Task<IEnumerable<SaleOrder>> GetAllOrdersAsync()
        {
            //return await _dbFactory.UsingAsync(async (db) => await db.QueryAsync<SaleOrder>("select * from SaleOrders;"));
            return await _dbFactory.Connection.QueryAsync<SaleOrder>("select * from SaleOrders;");
        }
    }
}
