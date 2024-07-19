using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgrammingDemoAPI
{
    public class IoAsyncTestMethods
    {
        private readonly ILogger<IoAsyncTestMethods> _logger;
        public IoAsyncTestMethods(ILogger<IoAsyncTestMethods> logger)
        {
            _logger = logger;
        }
        public  async Task Run()
        {
            //method is synchronous as no asynchronous operation is actually happening
            _logger.LogInformation($"Run method started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
            await WriteRandomTextFile();
            _logger.LogInformation($"Run method continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
        }

        private  async Task WriteRandomTextFile()
        {
            //method is synchronous as no asynchronous operation is actually happening
            _logger.LogInformation($"Write operation started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

            //First actual asynchronous IO-bound operation
            //method becomes asynchronous here
            await File.WriteAllTextAsync("Test.txt", "Testing asynchronous operation in .net");

            _logger.LogInformation($"Write operation done, Method continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
        }

        
    }
}
