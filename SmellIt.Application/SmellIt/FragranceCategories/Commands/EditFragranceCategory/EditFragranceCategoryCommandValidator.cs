using FluentValidation;

namespace SmellIt.Application.SmellIt.FragranceCategories.Commands.EditFragranceCategory
{
    public class EditFragranceCategoryCommandValidator : AbstractValidator<EditFragranceCategoryCommand>
    {
        public EditFragranceCategoryCommandValidator()
        {
            RuleFor(b => b.NamePL)
                .NotEmpty().WithMessage("Key is required")
                .MinimumLength(2).WithMessage("Key should have at least 2 characters")
                .MaximumLength(50).WithMessage("Key should have maximum of 50 characters");
            RuleFor(b => b.NameEN)
                .NotEmpty().WithMessage("Key is required")
                .MinimumLength(2).WithMessage("Key should have at least 2 characters")
                .MaximumLength(50).WithMessage("Key should have maximum of 50 characters");
        }
    }
}
