using FluentValidation;

namespace SmellIt.Application.SmellIt.Products.Commands.CreateProduct;
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(b => b.NamePl)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(2).WithMessage("Name should have at least 2 characters")
            .MaximumLength(50).WithMessage("Name should have maximum of 50 characters");
        RuleFor(b => b.NameEn)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(2).WithMessage("Name should have at least 2 characters")
            .MaximumLength(50).WithMessage("Name should have maximum of 50 characters");
    }
}
