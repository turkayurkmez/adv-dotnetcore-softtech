namespace EventsLibrary
{
    public class ProductPriceChangedEvent
    {
        public ProductPriceChangedCommand ProductPriceChangedCommand { get; set; }
    }

    public class ProductPriceChangedCommand
    {
        public int ProductId { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? NewPrice { get; set; }
    }

}
