namespace HW_6.Tasks.Factory
{
    internal class MyTaskFactory
    {
        public MyTaskFactory() { }

        public AbstractTask GetTask(TaskName taskName)
        {
            switch (taskName)
            {
                case TaskName.Task1: return new Task1();
                case TaskName.Task2: return new Task2();
                case TaskName.Task3: return new Task3();
                case TaskName.Task4: return new Task4();
                default: return null;
            }
        }
    }
}