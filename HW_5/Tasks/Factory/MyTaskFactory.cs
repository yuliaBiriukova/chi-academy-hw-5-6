using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HW_5.Tasks.Factory
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
                case TaskName.Task5: return new Task5();
                default: return null;
            }
        }
    }
}
