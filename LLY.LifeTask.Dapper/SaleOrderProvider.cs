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

    public class SaleOrderProvider : DapperDataProvider, ISaleOrderProvider
    {
        public IEnumerable<SaleOrder> GetAllOrders()
        {
            using (var db = GetDbConnection())
            {
                return db.Query<SaleOrder>("select * from SaleOrders");
                //return new List<SaleOrder>() { new SaleOrder() { OrderNo ="xyz" }, new SaleOrder() { OrderNo = "123" } };
            }
        }
    }
}
