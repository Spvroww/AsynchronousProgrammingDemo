using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgrammingDemoConsoleApp
{
    public  class IoSynchronousTestMethods
    {
        public static void Run()
        {
            //method is synchronous as no asynchronous operation is actually happening
            Console.WriteLine($"Run started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
            WriteRandomTextFile();
        }

        public static void WriteRandomTextFile()
        {
            Console.WriteLine($"Write operation started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

            //Running write operation synchronously
            //Thread is blocked till this completes
            File.WriteAllText("Test.txt", "Testing asynchronous operation in .net");

            Console.WriteLine($"Write operation done, Method continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
        }
    }
}
