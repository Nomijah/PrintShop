namespace PrintShop.GlobalData.Models.DTOs.GenericDtos
{
    public class VariantGetDto
    {
        public int Id { get; set; }
        public string SKUPart { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int MaterialId { get; set; }
        public int PrintSizeId { get; set; }
    }
}
