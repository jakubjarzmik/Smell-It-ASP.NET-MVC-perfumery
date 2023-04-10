using FluentValidation;
using SmellIt.Application.Dtos;
using SmellIt.Application.Extensions;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Validators;
public class BrandDtoValidator : AbstractValidator<BrandDto>
{
    private readonly IBrandRepository _brandRepository;

    public BrandDtoValidator(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;

        RuleFor(b => b.NamePL)
            .NotEmpty().WithMessage("Nazwa jest wymagana")
            .MinimumLength(2).WithMessage("Minimalna ilość znaków wynosi 2")
            .MaximumLength(50).WithMessage("Maksymalna ilość znaków wynosi 50");
        RuleFor(b => b.NameEN)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(2).WithMessage("The minimum number of characters is 2")
            .MaximumLength(50).WithMessage("The maximum number of characters is 50")
            .Custom((value, context) =>
            {
                var existingBrand = _brandRepository.GetByNameKey(value.ConvertNameToKey()).Result;
                if (existingBrand != null)
                {
                    context.AddFailure($"{value} is not unique key");
                }
            });
    }
}
