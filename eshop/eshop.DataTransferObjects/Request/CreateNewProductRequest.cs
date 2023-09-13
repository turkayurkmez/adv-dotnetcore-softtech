using System.ComponentModel.DataAnnotations;

namespace eshop.DataTransferObjects.Request
{
    public class CreateNewProductRequest
    {
        [Required(ErrorMessage = "Ürün adı boş olamaz")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public string? ImageUrl { get; set; } = "https://placehold.co/300x200";
    }
}
