using eshop.DataTransferObjects.Response;

namespace eshop.Application.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryMenuResponse> GetCategories();
    }
}