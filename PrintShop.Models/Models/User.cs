﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PrintShop.GlobalData.Models
{
    public class User : IdentityUser<Guid>
    {
        public ICollection<UserRole> UserRoles { get; set; }
        public Cart? Cart { get; set; }
        public List<UserOrder>? Orders { get; set; }
        public List<Favorite>? Favorites { get; set; }
    }
}