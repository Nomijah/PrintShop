namespace PrintShop.GlobalData.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string SKU { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid? PictureId { get; set; }
        public Picture Picture { get; set; } = null!;
        public int? VariantId { get; set; }
        public Variant Variant { get; set; } = null!;
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        //public List<DiscountProduct>? Discounts { get; set; }
        public Product()
        {
            SKU = Picture.SKUPart + Variant.SKUPart;
        }
    }
}
