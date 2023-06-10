using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Payments.Commands.EditPayment;
public class EditPaymentCommandHandler : IRequestHandler<EditPaymentCommand>
{
    private readonly IPaymentRepository _paymentRepository;

    public EditPaymentCommandHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }
    public async Task<Unit> Handle(EditPaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = (await _paymentRepository.GetByEncodedNameAsync(request.EncodedName))!;
        payment.ModifiedAt = DateTime.Now;

        UpdateTranslations(request, payment);

        await _paymentRepository.CommitAsync();

        return Unit.Value;
    }
    private void UpdateTranslations(EditPaymentCommand request, Payment payment)
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
        }
    }
}
