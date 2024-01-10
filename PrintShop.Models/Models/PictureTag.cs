namespace PrintShop.GlobalData.Models
{
    public class PictureTag
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int PictureId { get; set; }
        public Picture Picture { get; set; }
    }
}
