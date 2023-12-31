﻿using LoggingInDotnetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoggingInDotnetCore.Controllers
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
            _logger.LogInformation($"Index Action'u çalıştı! {DateTime.Now}");
            _logger.LogWarning("Warning");
            _logger.LogCritical("Critical");
            _logger.LogError("Error");

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