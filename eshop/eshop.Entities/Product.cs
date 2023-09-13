namespace eshop.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public string? ImageUrl { get; set; } = "https://placehold.co/300x200";
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Category? Category { get; set; }
        public int? CategoryId { get; set; }

    }
}
