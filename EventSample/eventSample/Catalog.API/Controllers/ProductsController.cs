using EventsLibrary;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IPublishEndpoint _endpoint;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IPublishEndpoint endpoint, ILogger<ProductsController> logger)
        {
            _endpoint = endpoint;
            _logger = logger;
        }

        [HttpPut]
        public IActionResult DiscountProduct(int productId, decimal newPrice)
        {
            var @event = new ProductPriceChangedEvent();
            var command = new ProductPriceChangedCommand { ProductId = productId, OldPrice = 100, NewPrice = newPrice };
            @event.ProductPriceChangedCommand = command;
            _endpoint.Publish(@event);
            _logger.LogInformation("Event fırlatıldı!");
            return Ok();
        }
    }
}
