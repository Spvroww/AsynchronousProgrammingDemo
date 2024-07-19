using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgrammingDemoConsoleApp
{
    public class CpuAsyncTestMethods
    {
        public static async Task Run()
        {
            //starts running synchronously
            Console.WriteLine($"run method started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");     
            
            //Although there is an asynchronous method being awaited here, this is not an actual asynchronous I/O bound operation so it still runs synchronously 
            await DoSomething();

            Console.WriteLine($"run method Continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

          
        }

        private static async Task DoSomething()
        {   
            //Runs synchronously as there is no asynchronous I/O bound operation
            Console.WriteLine($"DoSomething async method startd at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

            //Even if there is an asynchronous method being awaited here, this is not an actual asynchronous I/O bound operation so it still runs synchronously 
            await DoAnotherThing();    
            
            Console.WriteLine($"Do Something async method Continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

        }

        private static async Task DoAnotherThing()
        {
            //There is no I/O bound synchronous operation in our code. Our logic is strictly CPU bound.

            Console.WriteLine($"DoAnotherThing async method started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

            // To make a CPU bound operation asynchronous, we use the Task.Run method
            //our method becomes asynchronous at this point
            var task = Task.Run(() =>
            {
                var number = 10;
                for (int i = 0; i < 5; i++)
                {
                    number++;
                    Console.WriteLine($"DoAnotherThing-{i} with number: {number} executing in thread: {Thread.CurrentThread.ManagedThreadId}");
                }
            });
            await task;

            Console.WriteLine($"DoAnotherThing async method Continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

        }

    }
}
