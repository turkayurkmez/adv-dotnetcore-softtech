using eshop.DataTransferObjects.Request;
using eshop.DataTransferObjects.Response;

namespace eshop.Application.Services
{
    public interface IProductService
    {
        //İşlevlerin tamamı burada metot olarak eklenecek. Yani Ürün ile ilgili her işlem karşılığında bir fonksiyonla temsil edilecek
        //Stok azaldığında satıcıya mail at
        //Favoriye eklenen ürün fiyatı değiştiğinde mail at
        //Bu yaklaşımın alternatifi; her işlevi object olarak tanımlayan CQRS Pattern'dir.
        //Service yaklaşımı: Her bir işlev -> bir fonksiyon
        //CQRS: Her bir işlev -> bir nesne


        IEnumerable<ProductCardResponse> GetProducts();
        Task<IEnumerable<ProductCardResponse>> GetProductsAsync();
        ProductCardResponse GetProduct(int id);
        Task<ProductCardResponse> GetProductAsync(int id);

        Task<IEnumerable<ProductCardResponse>> SearchProductsByNameAsync(string name);
        Task<int> CreateNewProductAsync(CreateNewProductRequest createNewProductRequest);
        Task UpdateAsync(UpdateExistingProductRequest updateExistingProductRequest);
        Task DeleteAsync(int id);

        Task<bool> IsExists(int id);


    }
}
