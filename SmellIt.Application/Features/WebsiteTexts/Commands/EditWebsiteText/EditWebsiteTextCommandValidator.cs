using FluentValidation;

namespace SmellIt.Application.Features.WebsiteTexts.Commands.EditWebsiteText;

public class EditWebsiteTextCommandValidator : AbstractValidator<EditWebsiteTextCommand>
{
    public EditWebsiteTextCommandValidator()
    {
        RuleFor(b => b.TextPl)
            .NotEmpty().WithMessage("Text is required")
            .MinimumLength(2).WithMessage("Text should have at least 2 characters")
            .MaximumLength(255).WithMessage("Text should have maximum of 255 characters");
        RuleFor(b => b.TextEn)
            .NotEmpty().WithMessage("Text is required")
            .MinimumLength(2).WithMessage("Text should have at least 2 characters")
            .MaximumLength(255).WithMessage("Text should have maximum of 255 characters");
    }
}