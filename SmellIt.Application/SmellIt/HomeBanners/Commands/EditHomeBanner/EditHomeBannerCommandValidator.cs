using FluentValidation;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.HomeBanners.Commands.EditHomeBanner
{
    public class EditHomeBannerCommandValidator : AbstractValidator<EditHomeBannerCommand>
    {
        public EditHomeBannerCommandValidator()
        {
	        RuleFor(b => b.TextPL)
				.NotEmpty().WithMessage("Text is required")
				.MinimumLength(2).WithMessage("Text should have at least 2 characters")
				.MaximumLength(255).WithMessage("Text should have maximum of 255 characters");
			RuleFor(b => b.TextEN)
				.NotEmpty().WithMessage("Text is required")
				.MinimumLength(2).WithMessage("Text should have at least 2 characters")
				.MaximumLength(255).WithMessage("Text should have maximum of 255 characters");
			RuleFor(b => b.ImagePath)
				.NotEmpty().WithMessage("Image path is required")
				.MinimumLength(2).WithMessage("Image path should have at least 2 characters")
				.MaximumLength(255).WithMessage("Image path should have maximum of 255 characters");
			RuleFor(b => b.ImageAlt)
				.MaximumLength(50).WithMessage("Image path should have maximum of 50 characters");
		}
    }
}
