using FluentValidation;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.BLL.Validation.PictureValidators
{
    internal class PictureUploadValidator : AbstractValidator<PictureUploadDto>
    {
        public PictureUploadValidator() 
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("Image title must not be empty.");
            RuleFor(p => p.CreatorId).NotEmpty().WithMessage("CreatorId must not be empty.");
            RuleFor(p => p.File).NotEmpty().WithMessage("No file added.");
            RuleFor(p => p.File).Must(p => p.FileName.GetContentType() == "image/tiff" || p.FileName.GetContentType() == "image/jpeg");
        }
    }
}
