using eshop.Entities;

namespace eshop.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>, IRepositoryAsync<Product>
    {
        IList<Product> SearchProductsByName(string name);
        Task<IList<Product>> SearchProductsByNameAsync(string name);
    }

    //Aşağıdaki yapılar, kodu kirleteceği için alternatif bir yapı oluşturdum.
    //public interface IProductRepositoryAsync : IRepositoryAsync<Product>
    //{      

    //}

    //public interface IProductRepositoryGeneral : IProductRepository, IProductRepositoryAsync
    //{

    //}
}
