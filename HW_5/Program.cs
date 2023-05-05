using HW_5.Tasks.Factory;
using Microsoft.Extensions.Configuration;

namespace HW_5
{
    class Program
    {
        public static async Task Main()
        {
            MyTaskFactory taskFactory = new MyTaskFactory();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = await MenuAsync(taskFactory);
            }
        }

        private static async Task<bool> MenuAsync(MyTaskFactory taskFactory)
        {
            Console.Clear();
            Console.WriteLine("Select the task:");
            Console.WriteLine("\n1. Task 1. Get all orders for the last year (SqlCommand and SqlDataReader)");
            Console.WriteLine("2. Task 2. Get all orders for the last year (SqlDataAdapter and DataSet)");
            Console.WriteLine("3. Task 3. Add new record to Orders");
            Console.WriteLine("4. Task 4. Update record in Orders");
            Console.WriteLine("5. Task 5. Delete record from Orders");
            Console.WriteLine("\n0. Exit");
            Console.Write("\nTask > ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    await taskFactory.GetTask(TaskName.Task1).ExecuteAsync();
                    WaitUser();
                    return true;
                case "2":
                    Console.Clear();
                    await taskFactory.GetTask(TaskName.Task2).ExecuteAsync();
                    WaitUser();
                    return true;
                case "3":
                    Console.Clear();
                    await taskFactory.GetTask(TaskName.Task3).ExecuteAsync();
                    WaitUser();
                    return true;
                case "4":
                    Console.Clear();
                    await taskFactory.GetTask(TaskName.Task4).ExecuteAsync();
                    WaitUser();
                    return true;
                case "5":
                    Console.Clear();
                    await taskFactory.GetTask(TaskName.Task5).ExecuteAsync();
                    WaitUser();
                    return true;
                case "0":
                    return false;
                default:
                    Console.WriteLine("\nInvalid input! Enter number from 0 to 4!");
                    WaitUser();
                    return true;
            }
        }

        private static void WaitUser()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
    }
}