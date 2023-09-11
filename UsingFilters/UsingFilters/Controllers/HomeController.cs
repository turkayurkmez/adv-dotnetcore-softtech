using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UsingFilters.Filters;
using UsingFilters.Models;

namespace UsingFilters.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [LogAction]
        public IActionResult Index()
        {
            return View();
        }
        [NullReferenceException]
        public IActionResult Privacy()
        {
            throw new NullReferenceException("Bu nesnenin referansı yok!");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}