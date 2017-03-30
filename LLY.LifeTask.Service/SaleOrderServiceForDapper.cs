using LLY.LifeTask.Dapper;
using LLY.LifeTask.Model.Life;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LLY.LifeTask.Service
{
    public interface ISaleOrderDapperService
    {
        IEnumerable<SaleOrder> GetOrders();
    }
    public class SaleOrderServiceForDapper : ISaleOrderDapperService
    {
        private readonly ISaleOrderProvider _orderProvider;
        public SaleOrderServiceForDapper(ISaleOrderProvider orderRep)
        {
            _orderProvider = orderRep;
        }

        public IEnumerable<SaleOrder> GetOrders()
        {
            return _orderProvider.GetAllOrders();
        }

    }
}
