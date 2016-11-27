using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //var task = Task.Factory.StartNew<int>(SlowOperation);
            var task = SlowOperationAsync();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Slow operation result: {0}", task.Result);

            for (int i = 10; i < 15; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Main complete on {0}", Thread.CurrentThread.ManagedThreadId);
        }

        private static async Task<int> SlowOperationAsync()
        {
            Console.WriteLine("Slow operation started on {0}", 
                                        Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(2000);
            Console.WriteLine("Slow operation complete on {0}",
                                        Thread.CurrentThread.ManagedThreadId);
            return 42;
        }
    }
}
