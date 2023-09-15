using eshop.API.Filters;
using eshop.Application.Services;
using eshop.DataTransferObjects.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, IMemoryCache memoryCache, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetProducts()
        {
            // var products = 
            //intialize pattern: [cache'de] yoksa oluştur ve [cache'e at], aksi halde [cache'dekini] kullan.
            if (!_memoryCache.TryGetValue("all", out ProductsMemoryCache productsMemCache))
            {
                productsMemCache = new ProductsMemoryCache
                {
                    Products = await _productService.GetProductsAsync(),
                    CacheTime = DateTime.Now
                };


                var option = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(1))
                                                      .SetPriority(CacheItemPriority.High)
                                                      .RegisterPostEvictionCallback((key, value, reason, state) =>
                                                      {
                                                          _logger.LogInformation($"{key} değerindeki data, cache'den çıktı. Sebepi: {reason}, Çıkış zamanı:{DateTime.Now}    ");
                                                      });





                _memoryCache.Set("all", productsMemCache, option);
            }
            return Ok(productsMemCache);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Find(int id)
        {
            var product = _memoryCache.TryGetValue("all", out ProductsMemoryCache memCache) ?
                          memCache.Products.FirstOrDefault(p => p.Id == id)
                          :
                          await _productService.GetProductAsync(id);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound(new { message = $"{id} id'li ürün bulunamadı." });

        }
        [HttpGet("[action]/{name}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "name" })]
        public async Task<IActionResult> Search(string name)
        {
            var products = await _productService.SearchProductsByNameAsync(name);
            return Ok(new { result = products, cacheTime = DateTime.Now });
        }
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateNewProductRequest createNewProductRequest)
        {
            //if (ModelState.IsValid)
            //{
            var lastProductId = await _productService.CreateNewProductAsync(createNewProductRequest);
            var keys = ModelState.Keys;
            return CreatedAtAction(nameof(Find), routeValues: new { id = lastProductId }, value: null);

            //}

            return BadRequest(ModelState);
        }
        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [IsExists]
        public async Task<IActionResult> Update(int id, UpdateExistingProductRequest updateExistingProductRequest)
        {
            //if (await _productService.IsExists(id))
            //{
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(updateExistingProductRequest);
                return Ok();
            }
            return BadRequest(ModelState);
            //}
            //return NotFound(new { message = $"{id} id'li ürün bulunamadı." });
        }
        [Authorize]
        [IsExists]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            //if (await _productService.IsExists(id))
            //{
            await _productService.DeleteAsync(id);
            return Ok();
            //}
            //return NotFound(new { message = $"{id} id'li ürün bulunamadı." });
        }

    }
}
