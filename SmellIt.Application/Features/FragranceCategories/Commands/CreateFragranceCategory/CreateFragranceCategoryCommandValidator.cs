using FluentValidation;

namespace SmellIt.Application.Features.FragranceCategories.Commands.CreateFragranceCategory;
public class CreateFragranceCategoryCommandValidator : AbstractValidator<CreateFragranceCategoryCommand>
{
    public CreateFragranceCategoryCommandValidator()
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
