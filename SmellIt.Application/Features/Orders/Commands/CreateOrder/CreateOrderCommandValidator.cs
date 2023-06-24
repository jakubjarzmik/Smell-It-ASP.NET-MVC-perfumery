using FluentValidation;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Orders.Commands.CreateOrder;
public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator(IOrderRepository orderRepository)
    {
        RuleFor(b => b.FullName)
            .NotEmpty().WithMessage("Full Name is required")
            .MaximumLength(50).WithMessage("Full Name should have maximum of 50 characters");
        RuleFor(b => b.FirstLine)
            .NotEmpty().WithMessage("First Line is required")
            .MaximumLength(50).WithMessage("First Line should have maximum of 50 characters");
        RuleFor(b => b.SecondLine)
            .MaximumLength(50).WithMessage("Second Line should have maximum of 50 characters");
        RuleFor(b => b.PostalCode)
            .NotEmpty().WithMessage("Postal Code is required")
            .MaximumLength(10).WithMessage("Postal Code should have maximum of 10 characters");
        RuleFor(b => b.City)
            .NotEmpty().WithMessage("City is required")
            .MaximumLength(50).WithMessage("City should have maximum of 50 characters");
        RuleFor(b => b.PhoneNumber)
            .NotEmpty().WithMessage("Phone Number is required")
            .MaximumLength(20).WithMessage("Phone Number should have maximum of 20 characters");
    }
}
