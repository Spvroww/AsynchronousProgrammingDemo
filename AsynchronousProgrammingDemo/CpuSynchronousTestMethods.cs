using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgrammingDemoConsoleApp
{
    public class CpuSynchronousTestMethods
    {

        public static void Run()
        {           
            Console.WriteLine($"First async method startd at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
         
            DoSomething();

            Console.WriteLine($"First async method Continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");


        }

        private static void DoSomething()
        {
            
            Console.WriteLine($"Do Something method startd at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
           
            DoAnotherThing();

            Console.WriteLine($"Second async method Continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

        }

        private static void DoAnotherThing()
        {
            
            
            Console.WriteLine($"Third async method started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"DoAnotherThing-{i} executing in thread: {Thread.CurrentThread.ManagedThreadId}");

            }

            Console.WriteLine($"Third async method Continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

        }
    }
}
