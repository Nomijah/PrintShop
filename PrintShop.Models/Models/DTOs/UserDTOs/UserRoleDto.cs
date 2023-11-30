namespace PrintShop.GlobalData.Models.DTOs.UserDTOs
{
    public class UserRoleDto
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public IList<string>? RoleNames { get; set; }
    }
}
