using FluentValidation;
using PrintShop.GlobalData.Models.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.BLL.Validation.UserValidations
{
    public class UserLoginValidator :AbstractValidator<UserLoginDto>
    {
        public UserLoginValidator() 
        {
            RuleFor(u => u.UserName).NotEmpty().WithMessage("Email required.");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Password required.");
        }
    }
}
