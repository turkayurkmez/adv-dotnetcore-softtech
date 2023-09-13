using eshop.DataTransferObjects.Response;

namespace eshop.Application.Services
{
    public interface IProductService
    {
        IEnumerable<ProductCardResponse> GetProducts();
    }
}
