using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrintShop.GlobalData.Models
{
    public class UserRole : IdentityUserRole<Guid>
    {
        //public UserRole() : base()
        //{
        //}
        //public UserRole(
        //    User user,
        //    Role role)
        //{
        //    UserId = user.Id;
        //    RoleId = role.Id;
        //    User = user;
        //    Role = role;
        //}
        public virtual User User { get; private set; } = null!;
        public virtual Role Role { get; private set; } = null!;

        //[NotMapped]
        //public string RoleName => Role?.Name ?? string.Empty;
    }
}
