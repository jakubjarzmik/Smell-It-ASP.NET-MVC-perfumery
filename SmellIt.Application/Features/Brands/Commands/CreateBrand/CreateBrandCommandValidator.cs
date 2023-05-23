using FluentValidation;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Brands.Commands.CreateBrand;
public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator(IBrandRepository brandRepository)
    {
        RuleFor(b => b.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(2).WithMessage("Name should have at least 2 characters")
            .MaximumLength(50).WithMessage("Name should have maximum of 50 characters")
            .Custom((value, context) =>
            {
                var existingBrand = brandRepository.GetByName(value).GetAwaiter().GetResult();
                if (existingBrand != null)
                {
                    context.AddFailure($"{value} is not unique name for brand");
                }
            });
    }
}
