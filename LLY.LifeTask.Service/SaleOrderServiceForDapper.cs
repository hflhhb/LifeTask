﻿using LLY.LifeTask.Dapper;
using LLY.LifeTask.Model.Life;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LLY.LifeTask.Service
{
    public interface ISaleOrderDapperService
    {
        IEnumerable<SaleOrder> GetOrders();
        Task<IEnumerable<SaleOrder>> GetOrdersAsync();
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

        public async Task<IEnumerable<SaleOrder>> GetOrdersAsync()
        {
            return await _orderProvider.GetAllOrdersAsync();
        }

    }
}
