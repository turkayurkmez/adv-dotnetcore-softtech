namespace eshop.MVC.Models
{
    public class PageModel
    {
        public int PageSize { get; set; }
        public int TotalItemsCount { get; set; }
        public int TotalPages { get => (int)Math.Ceiling((decimal)TotalItemsCount / PageSize); }

        public int CurrentPage { get; set; }
    }
}
