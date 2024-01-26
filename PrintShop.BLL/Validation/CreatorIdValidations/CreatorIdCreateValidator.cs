using FluentValidation;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.BLL.Validation.CreatorIdValidations
{
    internal class CreatorIdCreateValidator : AbstractValidator<CreatorIdDto>
    {
        public CreatorIdCreateValidator() 
        {
            RuleFor(c => c.UserId).NotEmpty().WithMessage("UserId is required.");
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required.").MinimumLength(3).WithMessage("Name must be at least 3 characters long.");
        }
    }
}
