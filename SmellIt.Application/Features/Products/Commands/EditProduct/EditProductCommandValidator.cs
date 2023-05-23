using FluentValidation;

namespace SmellIt.Application.Features.Products.Commands.EditProduct
{
    public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            RuleFor(b => b.NamePl)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(2).WithMessage("Key should have at least 2 characters")
                .MaximumLength(50).WithMessage("Key should have maximum of 50 characters");
            RuleFor(b => b.NameEn)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(2).WithMessage("Key should have at least 2 characters")
                .MaximumLength(50).WithMessage("Key should have maximum of 50 characters");
            RuleFor(b => b.PriceValue)
                .NotEmpty().WithMessage("Price is required")
                .GreaterThan(0).WithMessage("Price should be greater than 0")
                .LessThan(10000000).WithMessage("Price should be less than 10,000,000");
            RuleFor(b => b.PromotionalPriceValue)
                .GreaterThan(0).WithMessage("Promotional Price should be greater than 0")
                .LessThan(10000000).WithMessage("Promotional Price should be less than 10,000,000");
        }
    }
}
