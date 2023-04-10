using FluentValidation;
using SmellIt.Application.Extensions;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Validators;
public class TranslationEngbValidator : AbstractValidator<TranslationEngb>
{
    private readonly ITranslationEngbRepository _translationEngbRepository;

    public TranslationEngbValidator(ITranslationEngbRepository translationEngbRepository)
    {
        _translationEngbRepository = translationEngbRepository;

        RuleFor(b => b.Key)
            .NotEmpty().WithMessage("Key is required")
            .MaximumLength(50).WithMessage("The maximum number of characters is 50")
            .Custom((value, context) =>
            {
                var existingTranslation = _translationEngbRepository.GetKey(value);
                if (existingTranslation != null)
                {
                    context.AddFailure($"{value} is not unique key");
                }
            });
    }
}
