using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgrammingDemoConsoleApp
{
    public class IoAsyncTestMethods
    {
        public static async Task Run()
        {
            //method is synchronous as no asynchronous operation is actually happening
            Console.WriteLine($"Run method started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
            await WriteRandomTextFile();
            Console.WriteLine($"Run method continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

        }

        private static async Task WriteRandomTextFile()
        {
            //method is synchronous as no asynchronous operation is actually happening
            Console.WriteLine($"Write operation started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

            //First actual asynchronous IO-bound operation
            //method becomes asynchronous here
            await File.WriteAllTextAsync("Test.txt", "Testing asynchronous operation in .net");

            Console.WriteLine($"Write operation done, Method continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
        }

        
    }
}
