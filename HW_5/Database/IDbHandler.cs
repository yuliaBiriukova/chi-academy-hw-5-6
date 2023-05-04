using HW_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5.Database
{
    internal interface IDbHandler
    {
        public Task<List<Order>> GetOrdersWithReaderAsync();
        public Task<List<Order>> GetOrdersWithDataSetAsync();
        public Task<List<Order>> GetOrdersByYearWithReaderAsync();
        public Task<List<Order>> GetOrdersByYearWithDataSetAsync();
        public Task<Order> GetOrderByIdAsync(int id);
        public Task<int> AddOrderAsync(Order newOrder);
        public Task<int> UpdateOrderAsync(Order newOrder);
        public Task<int> DeleteOrderAsync(int orderId);
    }
}
