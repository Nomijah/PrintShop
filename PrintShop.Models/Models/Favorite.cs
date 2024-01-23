namespace PrintShop.GlobalData.Models
{
    public class Favorite
    {
        //public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PictureId { get; set; }
    }
}