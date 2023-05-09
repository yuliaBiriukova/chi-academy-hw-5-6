using HW_6.Models;

namespace HW_6.Database
{
    internal interface IDbHandler
    {
        public List<Order> GetOrders();
        public List<Order> GetOrdersByYear();
        public Order GetOrderById(int id);
        public int AddOrder(Order newOrder);
        public int UpdateOrder(Order newOrder);
        public int DeleteOrder(Order order);
        public Analysis GetAnalysisById(int id);
    }
}