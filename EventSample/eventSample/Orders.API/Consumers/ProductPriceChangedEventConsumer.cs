using EventsLibrary;
using MassTransit;

namespace Orders.API.Consumers
{
    public class ProductPriceChangedEventConsumer : IConsumer<ProductPriceChangedEvent>
    {
        private readonly ILogger<ProductPriceChangedEventConsumer> _logger;

        public ProductPriceChangedEventConsumer(ILogger<ProductPriceChangedEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<ProductPriceChangedEvent> context)
        {
            var command = context.Message.ProductPriceChangedCommand;
            _logger.LogInformation($"{command.ProductId} id'li ürünün {command.OldPrice} olan fiyatı {command.NewPrice} olarak güncellendi");
            return Task.CompletedTask;
        }
    }
}
