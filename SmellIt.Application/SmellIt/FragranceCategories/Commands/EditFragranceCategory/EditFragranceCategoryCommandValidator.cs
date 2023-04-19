using FluentValidation;

namespace SmellIt.Application.SmellIt.FragranceCategories.Commands.EditFragranceCategory
{
    public class EditFragranceCategoryCommandValidator : AbstractValidator<EditFragranceCategoryCommand>
    {
        public EditFragranceCategoryCommandValidator()
        {
            RuleFor(b => b.NamePL)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(2).WithMessage("Name should have at least 2 characters")
                .MaximumLength(50).WithMessage("Name should have maximum of 50 characters");
            RuleFor(b => b.NameEN)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(2).WithMessage("Name should have at least 2 characters")
                .MaximumLength(50).WithMessage("Name should have maximum of 50 characters");
        }
    }
}
