using eshop.Entities;

namespace eshop.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IList<Product> SearchProductsByName(string name);
    }

    public interface IProductRepositoryAsync : IRepositoryAsync<Product>
    {

        Task<IList<Product>> SearchProductsByNameAsync(string name);

    }

    public interface IProductRepositoryGeneral : IProductRepository, IProductRepositoryAsync
    {

    }
}
