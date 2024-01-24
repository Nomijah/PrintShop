namespace PrintShop.GlobalData.Models
{
    public class CreatorId
    {
        public string Id { get; set; } = null!;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<Picture>? Pictures { get; set; }
        public string Name { get; set; } = null!;
        public string? Presentation { get; set; }
    }
}
