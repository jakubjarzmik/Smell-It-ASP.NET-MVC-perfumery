using FluentValidation;
using SmellIt.Application.Extensions;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Brands.Commands.CreateBrand;
public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    private readonly IBrandRepository _brandRepository;

    public CreateBrandCommandValidator(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;

        RuleFor(b => b.Name)
            .NotEmpty().WithMessage("Nazwa jest wymagana")
            .MinimumLength(2).WithMessage("Minimalna ilość znaków wynosi 2")
            .MaximumLength(50).WithMessage("Maksymalna ilość znaków wynosi 50");
    }
}
