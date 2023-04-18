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
            
        }
    }
}
