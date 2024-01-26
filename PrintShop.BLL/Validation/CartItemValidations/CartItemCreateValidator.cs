using FluentValidation;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.BLL.Validation.CartItemValidations
{
    internal class CartItemCreateValidator : AbstractValidator<CartItemCreateDto>
    {
        public CartItemCreateValidator()
        {
            RuleFor(ci => ci.CartId).NotEmpty().WithMessage("CartId is required.");
            RuleFor(ci => ci.ProductId).NotEmpty().WithMessage("ProductId is required.");
            RuleFor(ci => ci.Quantity).GreaterThan(0).WithMessage("Quantity must be more than 0.");
        }
    }
}
