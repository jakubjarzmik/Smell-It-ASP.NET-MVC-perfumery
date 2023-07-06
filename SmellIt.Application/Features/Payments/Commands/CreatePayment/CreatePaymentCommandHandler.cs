using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Payments.Commands.CreatePayment;
public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand>
{
    private readonly IUserContext _userContext;
    private readonly IPaymentRepository _paymentRepository;
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    public CreatePaymentCommandHandler(IUserContext userContext,IPaymentRepository paymentRepository, ILanguageRepository languageRepository, IMapper mapper)
    {
        _userContext = userContext;
        _paymentRepository = paymentRepository;
        _languageRepository = languageRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        var plLanguage = await _languageRepository.GetByCodeAsync("pl-PL");
        var enLanguage = await _languageRepository.GetByCodeAsync("en-GB");

        var payment = _mapper.Map<Payment>(request);

        if (plLanguage != null && enLanguage != null)
        {
            payment.PaymentTranslations = new List<PaymentTranslation>
            {
                new PaymentTranslation { Language = plLanguage, Name = request.NamePl, Description = request.DescriptionPl },
                new PaymentTranslation { Language = enLanguage, Name = request.NameEn, Description = request.DescriptionEn }
            };
        }

        await _paymentRepository.CreateAsync(payment);

        return Unit.Value;
    }
}