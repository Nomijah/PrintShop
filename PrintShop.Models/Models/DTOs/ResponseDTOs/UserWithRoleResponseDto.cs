namespace PrintShop.GlobalData.Models.DTOs.ResponseDTOs
{
    public class UserWithRoleResponseDto
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public bool emailConfirmed { get; set; }
        public ICollection<Role> roles { get; set; }
    }
}
