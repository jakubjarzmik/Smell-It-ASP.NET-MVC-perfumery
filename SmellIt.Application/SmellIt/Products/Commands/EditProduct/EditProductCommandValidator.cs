using FluentValidation;

namespace SmellIt.Application.SmellIt.Products.Commands.EditProduct
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
        }
    }
}
