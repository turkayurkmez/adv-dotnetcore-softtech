using eshop.Entities;

namespace eshop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        public IEnumerable<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category(){ Id=1, Name="Kırtasiye"},
                new Category(){ Id=2, Name="Elektronik"},
                new Category(){ Id=1, Name="Giyim"}

            };
        }
    }
}
