using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SmellIt.Application.Extensions;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Brands.Commands.EditBrand
{
    public class EditBrandCommandValidator : AbstractValidator<EditBrandCommand>
    {

        public EditBrandCommandValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("Nazwa jest wymagana")
                .MinimumLength(2).WithMessage("Minimalna ilość znaków wynosi 2")
                .MaximumLength(50).WithMessage("Maksymalna ilość znaków wynosi 50");
        }
    }
}
