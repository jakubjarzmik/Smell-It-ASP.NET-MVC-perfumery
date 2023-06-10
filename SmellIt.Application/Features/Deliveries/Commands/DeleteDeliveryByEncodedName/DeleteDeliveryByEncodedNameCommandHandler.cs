using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Deliveries.Commands.DeleteDeliveryByEncodedName;

public class DeleteDeliveryByEncodedNameCommandHandler : IRequestHandler<DeleteDeliveryByEncodedNameCommand>
{
    private readonly IDeliveryRepository _deliveryRepository;

    public DeleteDeliveryByEncodedNameCommandHandler(IDeliveryRepository deliveryRepository)
    {
        _deliveryRepository = deliveryRepository;
    }

    public async Task<Unit> Handle(DeleteDeliveryByEncodedNameCommand request, CancellationToken cancellationToken)
    {
        await _deliveryRepository.DeleteByEncodedNameAsync(request.EncodedName);
        return Unit.Value;
    }
}