using FluentValidation;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.BLL.Validation.PrintSizeValidations
{
    internal class PrintSizeCreateValidator : AbstractValidator<PrintSizeCreateDto>
    {
        public PrintSizeCreateValidator()
        {
            RuleFor(ps => ps.Height).NotEmpty().WithMessage("Height must be included.").GreaterThan(1).WithMessage("Height must be greater than 1.");
            RuleFor(ps => ps.Width).NotEmpty().WithMessage("Width must be included.").GreaterThan(1).WithMessage("Width must be greater than 1.");
        }
    }
}
