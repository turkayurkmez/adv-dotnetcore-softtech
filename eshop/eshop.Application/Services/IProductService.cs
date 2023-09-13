using eshop.DataTransferObjects.Response;

namespace eshop.Application.Services
{
    public interface IProductService
    {
        //İşlevlerin tamamı burada metot olarak eklenecek. Yani Ürün ile ilgili her işlem karşılığında bir fonksiyonla temsil edilecek
        //Stok azaldığında satıcıya mail at
        //Favoriye eklenen ürün fiyatı değiştiğinde mail at

        IEnumerable<ProductCardResponse> GetProducts();
    }
}
