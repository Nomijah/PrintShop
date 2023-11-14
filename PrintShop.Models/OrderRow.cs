namespace PrintShop.Models
{
    public class OrderRow
    {
        public int Id { get; set; }
        public int ArticleNumber { get; set; }
        public string PictureName { get; set; } = String.Empty;
        public string Material { get; set; } = String.Empty;
        public string Size { get; set; } = String.Empty;
        public int Quantity { get; set; }
        public decimal NetPrice { get; set; }
        public decimal Tax { get; set;}
        public decimal TotalPrice { get; set; }
    }
}