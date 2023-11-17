using FluentValidation;
using PrintShop.GlobalData.Models.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.BLL.Validation.UserValidations
{
    internal class PasswordUpdateValidator : AbstractValidator<PasswordUpdateDto>
    {
        public PasswordUpdateValidator() 
        {
            RuleFor(u => u.NewPassword).Matches(u => u.NewPasswordMatch).WithMessage("Passwords must match.");
            RuleFor(u => u.NewPassword).NotEmpty()
                .MinimumLength(8)
                .Matches("[A-Z]").WithMessage("'{PropertyName}' must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("'{PropertyName}' must contain one or more lowercase letters.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'{PropertyName}' must contain one or more special characters.")
                .Matches("^[^£# “”]*$").WithMessage("'{PropertyName}' must not contain the following characters £ # “” or spaces.");
            RuleFor(u => u.Email).NotEmpty();
        }
    }
}
