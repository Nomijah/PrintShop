namespace PrintShop.GlobalData.Models
{
    public class Picture
    {
        public Guid Id { get; set; }
        public string SKUPart { get; set; } = null!;
        public string CreatorId { get; set; } = null!;
        public string Url { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Width { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsActive { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Tag>? Tags { get; set; }
        //public List<Discount>? Discounts { get; set; }
        public List<Product>? Products { get; set; }

    }
}
