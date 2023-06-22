using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Payments.Commands.EditPayment;
public class EditPaymentCommandHandler : IRequestHandler<EditPaymentCommand>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUserContext _userContext;

    public EditPaymentCommandHandler(IPaymentRepository paymentRepository, IUserContext userContext)
    {
        _paymentRepository = paymentRepository;
        _userContext = userContext;
    }
    public async Task<Unit> Handle(EditPaymentCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        var payment = (await _paymentRepository.GetAsync(request.EncodedName))!;
        payment.ModifiedAt = DateTime.Now;
        payment.ModifiedById = currentUser.Id;

        UpdateTranslations(request, payment, currentUser.Id);

        await _paymentRepository.CommitAsync();

        return Unit.Value;
    }
    private void UpdateTranslations(EditPaymentCommand request, Payment payment, string currentUserId)
    {
        var translations = new Dictionary<string, (string Name, string? Description)>
        {
            { "pl-PL", (request.NamePl, request.DescriptionPl) },
            { "en-GB", (request.NameEn, request.DescriptionEn) }
        };

        foreach (var translation in translations)
        {
            var paymentTranslation = payment.PaymentTranslations.First(fct => fct.Language.Code == translation.Key);
            paymentTranslation.Name = translation.Value.Name;
            paymentTranslation.Description = translation.Value.Description;
            paymentTranslation.ModifiedAt = DateTime.Now;
            paymentTranslation.ModifiedById = currentUserId;
        }
    }
}
