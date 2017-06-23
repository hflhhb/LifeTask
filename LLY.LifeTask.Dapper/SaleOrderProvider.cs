using Dapper;
using LLY.LifeTask.Model.Life;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LLY.LifeTask.Dapper
{

    public interface ISaleOrderProvider
    {
        IEnumerable<SaleOrder> GetAllOrders();
    }

    public class SaleOrderProvider : ISaleOrderProvider
    {
        private readonly DapperDataProvider _dbFactory = null;

        public SaleOrderProvider(DapperDataProvider dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public IEnumerable<SaleOrder> GetAllOrders()
        {
            using (var db = _dbFactory.GetDbConnection())
            {
                return db.Query<SaleOrder>("select * from SaleOrders");
                //return new List<SaleOrder>() { new SaleOrder() { OrderNo ="xyz" }, new SaleOrder() { OrderNo = "123" } };
            }
        }
    }
}
