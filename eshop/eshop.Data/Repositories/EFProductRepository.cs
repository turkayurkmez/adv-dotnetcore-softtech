using eshop.Data.Context;
using eshop.Entities;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly EshopDbContext eshopDbContext;

        public EFProductRepository(EshopDbContext eshopDbContext)
        {
            this.eshopDbContext = eshopDbContext;
        }

        public void Create(Product entity)
        {
            eshopDbContext.Products.Add(entity);
            eshopDbContext.SaveChanges();
        }

        public async Task CreateAsync(Product entity)
        {
            await eshopDbContext.Products.AddAsync(entity);
            await eshopDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var item = eshopDbContext.Products.SingleOrDefault(p => p.Id == id);
            eshopDbContext.Remove(item);
            eshopDbContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var item = eshopDbContext.Products.SingleOrDefault(p => p.Id == id);
            eshopDbContext.Remove(item);
            await eshopDbContext.SaveChangesAsync();
        }

        public IList<Product> GetAll()
        {
            return eshopDbContext.Products.ToList();
        }

        public async Task<IList<Product>> GetAllAsync()
        {
            return await eshopDbContext.Products.ToListAsync();
        }

        public Product GetById(int id)
        {
            return eshopDbContext.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await eshopDbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        }

        public Task<bool> IsExistAsync(int id)
        {
            return eshopDbContext.Products.AnyAsync(p => p.Id == id);

        }

        public IList<Product> SearchProductsByName(string name)
        {
            return eshopDbContext.Products.Where(p => p.Name.Contains(name)).ToList();
        }

        public async Task<IList<Product>> SearchProductsByNameAsync(string name)
        {
            return await eshopDbContext.Products.Where(p => p.Name.Contains(name)).ToListAsync();

        }

        public void Update(Product entity)
        {
            eshopDbContext.Products.Update(entity);
            eshopDbContext.SaveChanges();
        }

        public async Task UpdateAsync(Product entity)
        {
            eshopDbContext.Products.Update(entity);
            await eshopDbContext.SaveChangesAsync();
        }
    }
}
