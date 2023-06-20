using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Deliveries.Commands.EditDelivery;
public class EditDeliveryCommandHandler : IRequestHandler<EditDeliveryCommand>
{
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly IUserContext _userContext;

    public EditDeliveryCommandHandler(IDeliveryRepository deliveryRepository, IUserContext userContext)
    {
        _deliveryRepository = deliveryRepository;
        _userContext = userContext;
    }
    public async Task<Unit> Handle(EditDeliveryCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        var delivery = (await _deliveryRepository.GetByEncodedNameAsync(request.EncodedName))!;
        delivery.ModifiedAt = DateTime.Now;
        delivery.ModifiedById = currentUser.Id;

        delivery.Price = request.Price;

        UpdateTranslations(request, delivery, currentUser.Id);

        await _deliveryRepository.CommitAsync();

        return Unit.Value;
    }
    private void UpdateTranslations(EditDeliveryCommand request, Delivery delivery, string currentUserId)
    {
        var translations = new Dictionary<string, (string Name, string? Description)>
        {
            { "pl-PL", (request.NamePl, request.DescriptionPl) },
            { "en-GB", (request.NameEn, request.DescriptionEn) }
        };

        foreach (var translation in translations)
        {
            var deliveryTranslation = delivery.DeliveryTranslations.First(fct => fct.Language.Code == translation.Key);
            deliveryTranslation.Name = translation.Value.Name;
            deliveryTranslation.Description = translation.Value.Description;
            deliveryTranslation.ModifiedAt = DateTime.Now;
            deliveryTranslation.ModifiedById = currentUserId;
        }
    }
}
