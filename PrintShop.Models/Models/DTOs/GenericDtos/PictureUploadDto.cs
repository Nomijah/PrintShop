namespace PrintShop.GlobalData.Models.DTOs.GenericDtos
{
    public class PictureUploadDto
    {
        public string CreatorIdentifier { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
    }
}
