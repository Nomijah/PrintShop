namespace PrintShop.GlobalData.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string SKUPart => "PI" + Id.ToString("D4");
        public string CreatorIdentifier { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Width { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsActive { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Tag>? Tags { get; set; }
        //public List<DiscountProduct>? Discounts { get; set; }
        public List<Product>? Products { get; set; }
    }
}
