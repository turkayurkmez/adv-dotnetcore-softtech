using eshop.Entities;

namespace eshop.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>, IRepositoryAsync<Category>
    {
    }
}
