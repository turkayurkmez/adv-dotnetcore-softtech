using eshop.Entities;

namespace eshop.Data.Repositories
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;
        public FakeCategoryRepository()
        {
            _categories = new List<Category>()
            {
                new Category(){ Id=1, Name="Kırtasiye"},
                new Category(){ Id=2, Name="Elektronik"},
                new Category(){ Id=1, Name="Giyim"}

            };
        }
        public void Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetAll()
        {
            return _categories;
        }

        public Task<IList<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
