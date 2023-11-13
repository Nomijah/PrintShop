using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PrintShop.Models
{
    public class User : IdentityUser
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public List<Order> Orders { get; set; }
    }
}