using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionsPattern.Models;
using OptionsPattern.Settings;
using System.Diagnostics;

namespace OptionsPattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptionsMonitor<SmtpSettings> _smtpOptions;

        public HomeController(ILogger<HomeController> logger, IOptionsMonitor<SmtpSettings> smtpOptions)
        {
            _logger = logger;
            _smtpOptions = smtpOptions;
        }

        public IActionResult Index()
        {
            /*
             * IOptions<>: Uygulama ayağa kalktıktan sonra bir daha okunmaz ve değişmez.
             * IOptionsSnapshot<>: Okunabilir ve scoped:
             * 
             */
            return View(_smtpOptions.CurrentValue);
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