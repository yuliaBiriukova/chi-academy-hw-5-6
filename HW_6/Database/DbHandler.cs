using HW_6.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HW_6.Database
{
    internal class DbHandler : IDbHandler
    {
        private AppDbContext appDbContext { get; set; }

        public DbHandler()
        {
            appDbContext= new AppDbContext();
        }

        public List<Order> GetOrders()
        {
            return appDbContext.Orders.Include(o => o.OrdAnalysis).Include(o => o.OrdAnalysis.AnGroup).ToList();
        }

        // get all orders for the last year
        public List<Order> GetOrdersByYear()
        {
            return appDbContext.Orders
                .Include(o => o.OrdAnalysis)
                .Include(o => o.OrdAnalysis.AnGroup)
                .Where(o => o.OrdDatetime >= DateTime.Now.AddYears(-1))
                .ToList();
        }

        public Order GetOrderById(int id)
        {
            return appDbContext.Orders
                .Include(o => o.OrdAnalysis)
                .Include(o => o.OrdAnalysis.AnGroup)
                .SingleOrDefault(o => o.Id == id);
        }

        // add record to Orders
        public int AddOrder(Order newOrder)
        {
            appDbContext.Orders.Add(newOrder);
            appDbContext.SaveChanges();
            return newOrder.Id;
        }

        // update record in Orders
        public int UpdateOrder(Order newOrder)
        {
            appDbContext.Orders.Update(newOrder);
            return appDbContext.SaveChanges();
        }

        // delete record from Orders
        public int DeleteOrder(Order order)
        {
            appDbContext.Orders.Remove(order);
            return appDbContext.SaveChanges();
        }

        public Analysis GetAnalysisById(int id)
        {
            return appDbContext.Analysis
                .Include(a => a.AnGroup)
                .SingleOrDefault(a => a.Id == id);
        }
    }
}