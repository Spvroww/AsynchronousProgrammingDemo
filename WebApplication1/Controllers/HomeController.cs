using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            _logger.LogInformation($"{Thread.CurrentThread.ManagedThreadId}");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation($"Main: {Thread.CurrentThread.ManagedThreadId}");
              DoStuffAsync();
            _logger.LogInformation($"Main continue: {Thread.CurrentThread.ManagedThreadId}");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void DoStuffAsync()
        {
                for (int i = 0; i < 200000; i++)
                {
                    _logger.LogInformation($"DoStuff-{i}: {Thread.CurrentThread.ManagedThreadId}");

                }
                     
        }
    }
}
