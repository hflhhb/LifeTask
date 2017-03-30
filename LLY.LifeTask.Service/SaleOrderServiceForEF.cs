using LLY.LifeTask.EntityFramework.Repositories;
using LLY.LifeTask.Model.Life;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LLY.LifeTask.Service
{
    public interface ISaleOrderEfService
    {
        Task<IEnumerable<SaleOrder>> GetOrdersAsync();
    }

    public class SaleOrderServiceForEF : ISaleOrderEfService
    {
        private readonly ISaleOrderRepository _orderRep;
        public SaleOrderServiceForEF(ISaleOrderRepository orderRep)
        {
            _orderRep = orderRep;
        }

        public async Task<IEnumerable<SaleOrder>> GetOrdersAsync()
        {
            return await _orderRep.GetAllOrders().ToListAsync();
        }

    }
}
