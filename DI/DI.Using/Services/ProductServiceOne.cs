using DI.Using.Models;

namespace DI.Using.Services
{
    public class ProductServiceOne : IProductService
    {
        public List<Product> GetProducts()
        {
            return new() {
                new() {  Id=1, Name="A", Description="B", Price=1},
                new() {  Id=2, Name="B", Description="B", Price=1},
                new() {  Id=3, Name="C", Description="B", Price=1},

            };
        }
    }
}
