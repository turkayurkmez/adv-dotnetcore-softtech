using eshop.Application.Services;
using eshop.Data.Context;
using eshop.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eshop.API.Extensions
{
    public static class IoCExtension
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<EshopDbContext>(option =>
             {
                 option.UseSqlServer(connectionString);
             });

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, FakeProductRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, FakeCategoryRepository>();

            return services;
        }
    }
}
