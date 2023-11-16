using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PrintShop.GlobalData.Models
{
    public class User : IdentityUser
    {
        public Cart? Cart { get; set; }
        public List<UserOrder>? Orders { get; set; }
        public List<Favorite>? Favorites { get; set; }
        public List<Payment>? Payments { get; set; }
        public List<Shipment>? Shipments { get; set; }
    }
}