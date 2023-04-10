using FluentValidation;
using SmellIt.Application.Extensions;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Validators;
public class TranslationPlplValidator : AbstractValidator<TranslationPlpl>
{
    private readonly ITranslationPlplRepository _translationPlplRepository;

    public TranslationPlplValidator(ITranslationPlplRepository translationPlplRepository)
    {
        _translationPlplRepository = translationPlplRepository;

        RuleFor(b => b.Key)
            .NotEmpty().WithMessage("Key is required")
            .MaximumLength(50).WithMessage("The maximum number of characters is 50")
            .Custom((value, context) =>
            {
                var existingTranslation = _translationPlplRepository.GetByKey(value).Result;
                if (existingTranslation != null)
                {
                    context.AddFailure($"{value} is not unique key");
                }
            });
    }
}
