using FluentValidation;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.HomeBanners.Commands.CreateHomeBanner;
public class CreateHomeBannerCommandValidator : AbstractValidator<CreateHomeBannerCommand>
{
    public CreateHomeBannerCommandValidator(IHomeBannerRepository homeBannerRepository)
    {
        RuleFor(b => b.Key)
            .NotEmpty().WithMessage("Key is required")
            .MinimumLength(2).WithMessage("Key should have at least 2 characters")
            .MaximumLength(50).WithMessage("Key should have maximum of 50 characters")
            .Custom((value, context) =>
            {
                var existingHomeBanner = homeBannerRepository.GetByKey(value).Result;
                if (existingHomeBanner != null)
                {
                    context.AddFailure($"{value} is not unique key for home banner");
                }
            });
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
