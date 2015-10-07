using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamDenton.WindowsServiceTaskDemo
{

    public class DemoUnitOfWork : IRepeatableWork
    {

        public TimeSpan DoWork()
        {
            try
            {
                Console.WriteLine($"RunUnitOfWork Thread: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                return TimeSpan.FromSeconds(5);
            }
            catch (Exception e)
            {
                return TimeSpan.FromMinutes(1);
            }

        }
    }
}
