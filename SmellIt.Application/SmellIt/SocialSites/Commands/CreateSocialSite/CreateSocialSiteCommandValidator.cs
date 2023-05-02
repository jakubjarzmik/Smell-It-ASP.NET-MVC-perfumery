using FluentValidation;

namespace SmellIt.Application.SmellIt.SocialSites.Commands.CreateSocialSite;
public class CreateSocialSiteCommandValidator : AbstractValidator<CreateSocialSiteCommand>
{
    public CreateSocialSiteCommandValidator()
    {
        RuleFor(b => b.Link)
            .NotEmpty().WithMessage("Link is required")
            .MinimumLength(2).WithMessage("Link should have at least 2 characters")
            .MaximumLength(255).WithMessage("Link should have maximum of 255 characters");
        RuleFor(b => b.Type)
            .NotEmpty().WithMessage("Type is required");
    }
}
