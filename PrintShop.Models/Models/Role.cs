using Microsoft.AspNetCore.Identity;

namespace PrintShop.GlobalData.Models
{
    public class Role : IdentityRole<Guid>
    {
        public Role() : base()
        {

        }
        public ICollection<User>? Users { get; set; }
    }
}