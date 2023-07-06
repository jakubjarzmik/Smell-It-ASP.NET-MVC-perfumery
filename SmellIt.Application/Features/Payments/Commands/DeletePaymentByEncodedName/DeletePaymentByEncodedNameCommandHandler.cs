using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Payments.Commands.DeletePaymentByEncodedName;

public class DeletePaymentByEncodedNameCommandHandler : IRequestHandler<DeletePaymentByEncodedNameCommand>
{
    private readonly IUserContext _userContext;
    private readonly IPaymentRepository _paymentRepository;

    public DeletePaymentByEncodedNameCommandHandler(IUserContext userContext,IPaymentRepository paymentRepository)
    {
        _userContext = userContext;
        _paymentRepository = paymentRepository;
    }

    public async Task<Unit> Handle(DeletePaymentByEncodedNameCommand request, CancellationToken cancellationToken)
    {
        await _paymentRepository.DeleteAsync(request.EncodedName);
        return Unit.Value;
    }
}