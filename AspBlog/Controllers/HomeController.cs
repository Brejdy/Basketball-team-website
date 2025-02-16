using AspBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Recruit()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }       
    }
}
