using eshop.Entities;

namespace eshop.Application.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}
