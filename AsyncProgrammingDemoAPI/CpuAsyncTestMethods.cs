using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgrammingDemoAPI
{
    public class CpuAsyncTestMethods
    {
        private readonly ILogger<CpuAsyncTestMethods> _logger;
        public CpuAsyncTestMethods(ILogger<CpuAsyncTestMethods> logger)
        {
            _logger = logger;
        }
        
        public async Task Run()
        {
            
            //starts running synchronously
            _logger.LogInformation($" run method started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");     
            
            //Although there is an asynchronous method being awaited here, this is not an actual asynchronous I/O bound operation so it still runs synchronously 
            await DoSomething();
            _logger.LogInformation($"run method Continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

          
        }

        private async Task DoSomething()
        {
            //Runs synchronously as there is no asynchronous I/O bound operation
            _logger.LogInformation($"DoSomething async method startd at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

            //Even if there is an asynchronous method being awaited here, this is not an actual asynchronous I/O bound operation so it still runs synchronously 
            await DoAnotherThing();

            _logger.LogInformation($"Do Something async method Continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

        }

        private  async Task DoAnotherThing()
        {
            //There is no I/O bound synchronous operation in our code. Our logic is strictly CPU bound.

            _logger.LogInformation($"DoAnotherThing async method started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
            
            // To make a CPU bound operation asynchronous, we use the Task.Run method
            //our method becomes asynchronous at this point
            await Task.Run(() =>
            {
                var number = 10;
                for (int i = 0; i < 2; i++)
                {
                    number++;
                    _logger.LogInformation($"DoAnotherThing-{i} executing in thread: {Thread.CurrentThread.ManagedThreadId}");

                }
            });

            _logger.LogInformation($"DoAnotherThing async method Continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

        }

    }
}
