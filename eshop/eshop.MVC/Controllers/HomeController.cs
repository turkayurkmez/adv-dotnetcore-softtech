using eshop.Application.Services;
using eshop.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eshop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index(int pageNo = 1)
        {
            var products = _productService.GetProducts();
            int pageSize = 1;
            var pageModel = new PageModel { CurrentPage = pageNo, PageSize = pageSize, TotalItemsCount = products.Count() };
            var paginated = products.OrderBy(x => x.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

            PaginatedProductsViewModel paginatedProductsViewModel = new PaginatedProductsViewModel
            {
                PageModel = pageModel,
                Products = paginated
            };


            return View(paginatedProductsViewModel);
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