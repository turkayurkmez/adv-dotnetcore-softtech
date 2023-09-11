using DI.LifeTime.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DI.LifeTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ISingletonGuid _singleton;
        private readonly ITransientGuid _transient;
        private readonly IScopedGuid _scoped;
        private readonly GuidService _guidService;
        public HomeController(ILogger<HomeController> logger, ISingletonGuid singleton, ITransientGuid transient, IScopedGuid scoped, GuidService guidService)
        {
            _logger = logger;
            _singleton = singleton;
            _transient = transient;
            _scoped = scoped;
            _guidService = guidService;

        }

        public IActionResult Index()
        {
            ViewBag.Singleton = _singleton.Guid.ToString();
            ViewBag.Transient = _transient.Guid.ToString();
            ViewBag.Scoped = _scoped.Guid.ToString();

            ViewBag.ServiceSingleton = _guidService.Singleton.Guid.ToString();
            ViewBag.ServiceTransient = _guidService.Transient.Guid.ToString();
            ViewBag.ServiceScoped = _guidService.ScopedGuid.Guid.ToString();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}