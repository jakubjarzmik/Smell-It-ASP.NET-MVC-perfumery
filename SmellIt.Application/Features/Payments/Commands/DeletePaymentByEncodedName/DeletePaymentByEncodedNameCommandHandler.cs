using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Payments.Commands.DeletePaymentByEncodedName;

public class DeletePaymentByEncodedNameCommandHandler : IRequestHandler<DeletePaymentByEncodedNameCommand>
{
    private readonly IPaymentRepository _paymentRepository;

    public DeletePaymentByEncodedNameCommandHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<Unit> Handle(DeletePaymentByEncodedNameCommand request, CancellationToken cancellationToken)
    {
        await _paymentRepository.DeleteByEncodedNameAsync(request.EncodedName);
        return Unit.Value;
    }
}