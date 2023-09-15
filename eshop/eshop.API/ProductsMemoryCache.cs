using eshop.DataTransferObjects.Response;

namespace eshop.API
{
    public class ProductsMemoryCache
    {
        public IEnumerable<ProductCardResponse> Products { get; set; }
        public DateTime CacheTime { get; set; }
    }
}
