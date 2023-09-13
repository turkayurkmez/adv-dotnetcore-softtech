using eshop.Entities;

namespace eshop.Application.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
    }
}