using FluentValidation;
using PrintShop.GlobalData.Models.DTOs.GeneralDtos;

namespace PrintShop.BLL.Validation.MaterialValidations
{
    internal class MaterialValidator : AbstractValidator<MaterialCreateDto>
    {
        public MaterialValidator() 
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Name can not be empty.");
        }
    }
}
