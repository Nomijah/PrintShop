using Microsoft.AspNetCore.Http;

namespace PrintShop.GlobalData.Models.DTOs.GenericDtos
{
    public class PictureUploadDto
    {
        public string CreatorId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public bool IsActive { get; set; } = false;
        public IFormFile File { get; set; } = null!;
    }
}
