namespace PrintShop.Models
{
    public class PrintSize
    {
        public int Id { get; set; }
        public int ArticleCode { get; set; }
        public string? Size { get; set; } // String description of size, e.g. 50x100
        public decimal Height { get; set; }
        public decimal Width { get; set; }
    }
}