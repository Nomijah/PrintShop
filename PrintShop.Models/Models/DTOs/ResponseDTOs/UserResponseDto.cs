namespace PrintShop.GlobalData.Models.DTOs.ResponseDTOs
{
    public class UserResponseDto
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public bool emailConfirmed { get; set; }
    }
}
