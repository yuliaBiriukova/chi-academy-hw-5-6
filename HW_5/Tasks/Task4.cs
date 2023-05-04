using HW_5.Database;
using HW_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5.Tasks
{
    internal class Task4 : AbstractTask
    {
        // update record in Orders
        public override async Task ExecuteAsync()
        {
            Console.WriteLine("Task 4");
            Console.WriteLine();

            DbHandler dbHandler = new DbHandler();

            Order newOrder = new Order()
            {
                ord_id = 1,
                ord_datetime = DateTime.Now,
                ord_an = new Analysis()
                {
                    an_id = 10,
                }
            };

            Console.WriteLine("Order before update:");
            Order order = await dbHandler.GetOrderByIdAsync(1);
            Console.WriteLine(order);

            var count = await dbHandler.UpdateOrderAsync(newOrder);
            Console.WriteLine(count + " rows updated");

            Console.WriteLine("\nOrder after update:");
            order = await dbHandler.GetOrderByIdAsync(1);
            Console.WriteLine(order);
        }
    }
}
