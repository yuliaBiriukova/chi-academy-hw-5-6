using HW_5.Database;
using HW_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5.Tasks
{
    internal class Task1 : AbstractTask
    {
        // get all orders for the last year
        // use SqlCommand and SqlDataReader
        public override async Task ExecuteAsync()
        {
            Console.WriteLine("Task 1");
            Console.WriteLine();

            DbHandler dbHandler = new DbHandler();
            List<Order> orders = new List<Order>();

            orders = await dbHandler.GetOrdersByYearWithReaderAsync();
            
            Console.WriteLine("Orders for the last year:");

            foreach (var order in orders)
            {
                Console.WriteLine(order);
                Console.WriteLine();
            }
        }
    }
}
