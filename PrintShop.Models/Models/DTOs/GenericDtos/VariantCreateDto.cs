namespace PrintShop.GlobalData.Models.DTOs.GenericDtos
{
    public class VariantCreateDto
    {
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int MaterialId { get; set; }
        public int PrintSizeId { get; set; }
    }
}
