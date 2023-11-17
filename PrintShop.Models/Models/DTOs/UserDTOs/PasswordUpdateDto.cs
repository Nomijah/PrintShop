using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.GlobalData.Models.DTOs.UserDTOs
{
    public class PasswordUpdateDto
    {
        public string Email { get; set; } = String.Empty;
        public string CurrentPassword { get; set; } = String.Empty;
        public string NewPassword { get; set; } = String.Empty;
        public string NewPasswordMatch { get; set; } = String.Empty; 
    }
}
