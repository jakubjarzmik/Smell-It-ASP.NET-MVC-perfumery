using FluentValidation;

namespace SmellIt.Application.Features.SocialSites.Commands.EditSocialSite
{
    public class EditSocialSiteCommandValidator : AbstractValidator<EditSocialSiteCommand>
    {
        public EditSocialSiteCommandValidator()
        {
            RuleFor(b => b.Link)
                .NotEmpty().WithMessage("Link is required")
                .MinimumLength(2).WithMessage("Link should have at least 2 characters")
                .MaximumLength(255).WithMessage("Link should have maximum of 255 characters");
        }
    }
}
