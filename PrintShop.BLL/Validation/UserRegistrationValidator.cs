using FluentValidation;
using PrintShop.GlobalData.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.BLL.Validation
{
    internal class UserRegistrationValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegistrationValidator()
        {
            RuleFor(u => u.Password).NotEmpty()
                .MinimumLength(8)
                .Matches("[A-Z]").WithMessage("'{PropertyName}' must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("'{PropertyName}' must contain one or more lowercase letters.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'{ PropertyName}' must contain one or more special characters.")
                .Matches("^[^£# “”]*$").WithMessage("'{PropertyName}' must not contain the following characters £ # “” or spaces.");
            RuleFor(u => u.Email).EmailAddress();
        }
    }
}
