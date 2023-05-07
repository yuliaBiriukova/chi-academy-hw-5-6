using HW_6.Database;
using HW_6.Models;
using HW_6.Tasks.Factory;

namespace HW_6
{
    class Program
    {
        public static void Main()
        {
            MyTaskFactory taskFactory = new MyTaskFactory();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Menu(taskFactory);
            }
        }

        private static bool Menu(MyTaskFactory taskFactory)
        {
            Console.Clear();
            Console.WriteLine("Select the task:");
            Console.WriteLine("\n1. Task 1. Get all orders for the last year");
            Console.WriteLine("2. Task 2. Add new record to Orders");
            Console.WriteLine("3. Task 3. Update record in Orders");
            Console.WriteLine("4. Task 4. Delete record from Orders");
            Console.WriteLine("\n0. Exit");
            Console.Write("\nTask > ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    taskFactory.GetTask(TaskName.Task1).Execute();
                    WaitUser();
                    return true;
                case "2":
                    Console.Clear();
                    taskFactory.GetTask(TaskName.Task2).Execute();
                    WaitUser();
                    return true;
                case "3":
                    Console.Clear();
                    taskFactory.GetTask(TaskName.Task3).Execute();
                    WaitUser();
                    return true;
                case "4":
                    Console.Clear();
                    taskFactory.GetTask(TaskName.Task4).Execute();
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