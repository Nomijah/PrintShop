namespace PrintShop.GlobalData.Models
{
    public class Variant
    {
        public int Id { get; set; }
        public string SKUPart { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int MaterialId { get; set; }
        public Material? Material { get; set; }
        public int PrintSizeId { get; set; }
        public PrintSize? Size { get; set; }
        public List<DiscountProduct>? Discounts { get; set; }
    }
}