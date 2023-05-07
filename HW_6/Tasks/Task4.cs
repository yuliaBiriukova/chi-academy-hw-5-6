using HW_6.Database;
using HW_6.Models;

namespace HW_6.Tasks
{
    internal class Task4 : AbstractTask
    {
        // delete record from Orders
        public override void Execute()
        {
            Console.WriteLine("Task 4");
            Console.WriteLine();

            DbHandler dbHandler = new DbHandler();

            Order order = dbHandler.GetOrderById(183);

            Console.WriteLine("Order to delete:\n");
            Console.WriteLine(order);

            var count = dbHandler.DeleteOrder(order);
            Console.WriteLine();
            Console.WriteLine(count + " rows deleted");
        }
    }
}