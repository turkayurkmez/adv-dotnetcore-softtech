using System.ComponentModel.DataAnnotations;

namespace eshop.DataTransferObjects.Request
{
    public class CreateNewProductRequest
    {
        [Required(ErrorMessage = "Ürün adı boş olamaz")]
        [MinLength(3, ErrorMessage = "En az üç karakter...")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ürün açıklaması boş olamaz")]
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public string? ImageUrl { get; set; } = "https://placehold.co/300x200";
    }
}
