using HW_5.Database;
using HW_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5.Tasks
{
    internal class Task2 : AbstractTask
    {
        // get all orders for the last year
        // use SqlDataAdapter and DataSet
        public override async Task ExecuteAsync()
        {
            Console.WriteLine("Task 2");
            Console.WriteLine();

            DbHandler dbHandler = new DbHandler();
            List<Order> orders = new List<Order>();

            orders = await dbHandler.GetOrdersByYearWithDataSetAsync();

            Console.WriteLine("Orders for the last year:");

            foreach (var order in orders)
            {
                Console.WriteLine(order);
                Console.WriteLine();
            }
        }
    }
}
