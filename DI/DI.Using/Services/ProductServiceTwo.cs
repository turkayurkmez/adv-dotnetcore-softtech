using DI.Using.Models;

namespace DI.Using.Services
{
    public class ProductServiceTwo : IProductService
    {
        public List<Product> GetProducts()
        {
            return new() {
                new() {  Id=1, Name="X", Description="X", Price=1},
                new() {  Id=2, Name="Y", Description="Y", Price=1},
                new() {  Id=3, Name="Z", Description="Z", Price=1},

            };
        }
    }
}
