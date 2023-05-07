using HW_6.Database;
using HW_6.Models;

namespace HW_6.Tasks
{
    internal class Task3 : AbstractTask
    {
        // update record in Orders
        public override void Execute()
        {
            Console.WriteLine("Task 3");
            Console.WriteLine();

            DbHandler dbHandler = new DbHandler();

            Console.WriteLine("Order before update:");
            Order order = dbHandler.GetOrderById(1);
            Console.WriteLine(order);

            order.OrdAnalysis = dbHandler.GetAnalysisById(1);

            var count = dbHandler.UpdateOrder(order);
            Console.WriteLine();
            Console.WriteLine(count + " rows updated");

            Console.WriteLine("\nOrder after update:");
            Console.WriteLine(order);
        }
    }
}
