using Microsoft.AspNetCore.Identity;

namespace PrintShop.GlobalData.Models
{
    public class Role : IdentityRole<Guid>
    {
        public Role() : base()
        {

        }
        public ICollection<UserRole>? UserRoles { get; set; }
    }
}