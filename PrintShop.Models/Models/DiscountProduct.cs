namespace PrintShop.GlobalData.Models
{
    public class DiscountProduct
    {
        public int Id { get; set; }
        public int DiscountId { get; set; }
        public int? PictureId { get; set; }
        public int? ProductId { get; set; }
        public int? VariantId { get; set; }
    }
}