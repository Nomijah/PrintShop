using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.GlobalData.Models.DTOs
{
    public class UserRegisterDto
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string PasswordMatch { get; set; } = String.Empty;
    }
}
