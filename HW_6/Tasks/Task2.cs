using HW_6.Database;
using HW_6.Models;

namespace HW_6.Tasks
{
    internal class Task2 : AbstractTask
    {
        // add new record to Orders
        public override void Execute()
        {
            Console.WriteLine("Task 2");
            Console.WriteLine();

            DbHandler dbHandler = new DbHandler();

            Order newOrder = new Order()
            {
                OrdDatetime = DateTime.Now,
                OrdAnalysis = dbHandler.GetAnalysisById(1)
            };

            var id = dbHandler.AddOrder(newOrder);

            Console.WriteLine("Added order:");
            Console.WriteLine(newOrder);
        }
    }
}