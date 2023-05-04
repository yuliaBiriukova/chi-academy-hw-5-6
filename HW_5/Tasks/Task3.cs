using HW_5.Database;
using HW_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5.Tasks
{
    internal class Task3 : AbstractTask
    {
        // add new record to Orders
        public override async Task ExecuteAsync()
        {
            Console.WriteLine("Task 3");
            Console.WriteLine();

            DbHandler dbHandler = new DbHandler();

            Order newOrder = new Order()
            {
                ord_datetime = DateTime.Now,
                ord_an = new Analysis()
                {
                    an_id = 10,
                }
            };

            var id = await dbHandler.AddOrderAsync(newOrder);
            Order order = await dbHandler.GetOrderByIdAsync(id);
            
            Console.WriteLine("Added order:");
            Console.WriteLine(order);
        }
    }
}
