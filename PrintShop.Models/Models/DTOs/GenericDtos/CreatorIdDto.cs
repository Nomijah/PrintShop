namespace PrintShop.GlobalData.Models.DTOs.GenericDtos
{
    public class CreatorIdDto
    {
        public string Id { get; set; } = null!;
        public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
        public string? Presentation { get; set; }
    }
}
