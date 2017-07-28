using LLY.LifeTask.Model.Life;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LLY.LifeTask.Service
{
    public interface ISaleOrderService
    {
        Task<IEnumerable<SaleOrder>> GetOrdersAsync();
        Task<IEnumerable<SaleOrder>> GetOrdersDapperAsync();
        IEnumerable<SaleOrder> GetOrders();
    }

    public class SaleOrderService : ISaleOrderService
    {
        public ISaleOrderDapperService _dapperSvr;
        public ISaleOrderEfService _efSvr;

        public SaleOrderService(ISaleOrderDapperService dapperSvr, ISaleOrderEfService efSvr)
        {
            _dapperSvr = dapperSvr;
            _efSvr = efSvr;
        }
        public IEnumerable<SaleOrder> GetOrders()
        {
            return _dapperSvr.GetOrders();
        }
        public async Task<IEnumerable<SaleOrder>> GetOrdersDapperAsync()
        {
            return await _dapperSvr.GetOrdersAsync();
        }

        public async Task<IEnumerable<SaleOrder>> GetOrdersAsync()
        {
            return await _efSvr.GetOrdersAsync();
        }
    }
}
