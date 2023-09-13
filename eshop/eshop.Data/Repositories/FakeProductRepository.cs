using eshop.Entities;

namespace eshop.Data.Repositories
{
    public class FakeProductRepository : IProductRepositoryGeneral
    {
        IList<Product> products = new List<Product>();
        public FakeProductRepository()
        {
            products = new List<Product>()
            {
                new Product { Id = 1, Description="Test", Name="Product A", Price=1, ImageUrl="https://placehold.co/300x200" },
                new Product { Id = 2, Description="Test", Name="Product B", Price=1, ImageUrl="https://placehold.co/300x200" },
                new Product { Id = 3, Description="Test", Name="Product X", Price=1, ImageUrl="https://placehold.co/300x200" },


            };
        }
        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Product entity)
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

        public IList<Product> GetAll()
        {
            return products;
        }

        public Task<IList<Product>> GetAllAsync()
        {
            return Task.FromResult(products);
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> SearchProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> SearchProductsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
