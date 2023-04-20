using FluentValidation;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Brands.Commands.CreateBrand;
public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator(IBrandRepository brandRepository)
    {
        RuleFor(b => b.Name)
            .NotEmpty().WithMessage("Key is required")
            .MinimumLength(2).WithMessage("Key should have at least 2 characters")
            .MaximumLength(50).WithMessage("Key should have maximum of 50 characters")
            .Custom((value, context) =>
            {
                var existingBrand = brandRepository.GetByName(value).Result;
                if (existingBrand != null)
                {
                    context.AddFailure($"{value} is not unique name for brand");
                }
            });
    }
}
