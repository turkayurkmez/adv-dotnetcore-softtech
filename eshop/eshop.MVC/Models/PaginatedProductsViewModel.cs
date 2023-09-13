using eshop.DataTransferObjects.Response;

namespace eshop.MVC.Models
{
    public class PaginatedProductsViewModel
    {
        public PageModel PageModel { get; set; }
        public IEnumerable<ProductCardResponse> Products { get; set; }
    }
}
