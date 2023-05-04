using HW_5.Database;
using HW_5.Models;

namespace HW_5.Tasks
{
    internal class Task5 : AbstractTask
    {
        // delete record from Orders
        public override async Task ExecuteAsync()
        {
            Console.WriteLine("Task 5");
            Console.WriteLine();

            DbHandler dbHandler = new DbHandler();

            Order order = await dbHandler.GetOrderByIdAsync(199);

            Console.WriteLine("Oкder to delete:");
            Console.WriteLine(order);
           
            var count = await dbHandler.DeleteOrderAsync(order.ord_id);
            Console.WriteLine(count + " rows deleted");

        }
    }
}
