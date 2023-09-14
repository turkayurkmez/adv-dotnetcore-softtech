using eshop.Application.Services;
using eshop.DataTransferObjects.Request;
using Microsoft.AspNetCore.Mvc;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Find(int id)
        {
            var product = await _productService.GetProductAsync(id);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound(new { message = $"{id} id'li ürün bulunamadı." });

        }
        [HttpGet("[action]/{name}")]
        public async Task<IActionResult> Search(string name)
        {
            var products = await _productService.SearchProductsByNameAsync(name);
            return Ok(products);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateNewProductRequest createNewProductRequest)
        {
            if (ModelState.IsValid)
            {
                var lastProductId = await _productService.CreateNewProductAsync(createNewProductRequest);
                var keys = ModelState.Keys;
                return CreatedAtAction(nameof(Find), routeValues: new { id = lastProductId }, value: null);

            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Update(int id, UpdateExistingProductRequest updateExistingProductRequest)
        {
            if (id == updateExistingProductRequest.Id && await _productService.IsExists(id))
            {
                if (ModelState.IsValid)
                {
                    await _productService.UpdateAsync(updateExistingProductRequest);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _productService.IsExists(id))
            {
                await _productService.DeleteAsync(id);
            }
            return NotFound(new { message = $"{id} id'li ürün bulunamadı." });
        }

    }
}
