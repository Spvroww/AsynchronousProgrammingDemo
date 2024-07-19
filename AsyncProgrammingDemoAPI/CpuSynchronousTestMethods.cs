using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgrammingDemoAPI
{
    public class CpuSynchronousTestMethods
    {
        private readonly ILogger<CpuSynchronousTestMethods> _logger;
        public CpuSynchronousTestMethods(ILogger<CpuSynchronousTestMethods> logger)
        {
            _logger = logger;
        }
        public void Run()
        {
            _logger.LogInformation($"Run async method started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
         
            DoSomething();

            _logger.LogInformation($"Run async method Continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");


        }

        private  void DoSomething()
        {

            _logger.LogInformation($"DoSomething method startd at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
           
            DoAnotherThing();

            _logger.LogInformation($"DoSomething async method Continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

        }

        private  void DoAnotherThing()
        {

            _logger.LogInformation($"DoAnotherThing async method started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

            for (int i = 0; i < 2; i++)
            {
                _logger.LogInformation($"DoAnotherThing-{i} executing in thread: {Thread.CurrentThread.ManagedThreadId}");

            }

            _logger.LogInformation($"DoAnotherThing async method Continues at Thread: {Thread.CurrentThread.ManagedThreadId}\n");

        }
    }
}
