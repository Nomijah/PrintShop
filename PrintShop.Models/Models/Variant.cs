namespace PrintShop.GlobalData.Models
{
    public class Variant
    {
        public int Id { get; set; }
        public string SKUPart { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; } = null!;
        public int PrintSizeId { get; set; }
        public PrintSize Size { get; set; } = null!;
        //public List<DiscountProduct>? Discounts { get; set; }

        public Variant()
        {
            SKUPart = MaterialId.ToString("D2") + Size.SKUPart;
        }

    }
}