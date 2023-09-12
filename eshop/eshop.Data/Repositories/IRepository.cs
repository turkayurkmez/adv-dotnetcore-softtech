using eshop.Entities;

namespace eshop.Data.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IList<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);

    }

    public interface IRepositoryAsync<T> where T : class, IEntity, new()
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

    }
}
