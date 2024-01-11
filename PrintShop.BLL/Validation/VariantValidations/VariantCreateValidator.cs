using FluentValidation;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.BLL.Validation.VariantValidations
{
    internal class VariantCreateValidator : AbstractValidator<VariantCreateDto>
    {
        public VariantCreateValidator() 
        {
            RuleFor(v => v.MaterialId).NotEmpty().WithMessage("MaterialId can not be empty.");
            RuleFor(v => v.PrintSizeId).NotEmpty().WithMessage("PrintSizeId can not be empty.");
        }
    }
}
