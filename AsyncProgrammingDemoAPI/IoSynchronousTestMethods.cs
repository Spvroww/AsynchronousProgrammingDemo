using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgrammingDemoAPI
{
    public  class IoSynchronousTestMethods
    {
        private readonly ILogger<IoSynchronousTestMethods> _logger;
        public IoSynchronousTestMethods(ILogger<IoSynchronousTestMethods> logger)
        {
            _logger = logger;
        }
        public  void Run()
        {
            //method is synchronous as no asynchronous operation is actually happening
            _logger.LogInformation($"Run method started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
            WriteRandomTextFile();
            _logger.LogInformation($"Run method continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
        }

        public  void WriteRandomTextFile()
        {
            _logger.LogInformation($"Write operation started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

            //Running write operation synchronously
            //Thread is blocked till this completes
            File.WriteAllText("Test.txt", "Testing asynchronous operation in .net");

            _logger.LogInformation($"Write operation done, Method continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
        }
    }
}
