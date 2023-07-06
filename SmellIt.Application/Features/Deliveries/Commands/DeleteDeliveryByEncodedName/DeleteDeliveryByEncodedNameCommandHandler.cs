using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Deliveries.Commands.DeleteDeliveryByEncodedName;

public class DeleteDeliveryByEncodedNameCommandHandler : IRequestHandler<DeleteDeliveryByEncodedNameCommand>
{
    private readonly IUserContext _userContext;
    private readonly IDeliveryRepository _deliveryRepository;

    public DeleteDeliveryByEncodedNameCommandHandler(IUserContext userContext, IDeliveryRepository deliveryRepository)
    {
        _userContext = userContext;
        _deliveryRepository = deliveryRepository;
    }

    public async Task<Unit> Handle(DeleteDeliveryByEncodedNameCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        await _deliveryRepository.DeleteAsync(request.EncodedName);
        return Unit.Value;
    }
}