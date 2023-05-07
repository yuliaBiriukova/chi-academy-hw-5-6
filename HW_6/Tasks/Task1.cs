using HW_6.Database;
using HW_6.Models;

namespace HW_6.Tasks
{
    internal class Task1 : AbstractTask
    {
        // get all orders for the last year
        public override void Execute()
        {
            Console.WriteLine("Task 1");
            Console.WriteLine();

            DbHandler dbHandler = new DbHandler();
            List<Order> orders = dbHandler.GetOrdersByYear();

            Console.WriteLine("Orders for the last year:\n");

            foreach (var order in orders)
            {
                Console.WriteLine(order);
                Console.WriteLine();
            }
        }
    }
}