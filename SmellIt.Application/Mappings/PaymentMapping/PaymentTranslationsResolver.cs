using AutoMapper;
using SmellIt.Application.Features.Payments.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.PaymentMapping;
public class PaymentTranslationsResolver : IValueResolver<PaymentDto, Payment, ICollection<PaymentTranslation>>
{
    private readonly ILanguageRepository _languageRepository;

    public PaymentTranslationsResolver(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public ICollection<PaymentTranslation> Resolve(PaymentDto source, Payment destination, ICollection<PaymentTranslation> destMember, ResolutionContext context)
    {
        var plLanguage = _languageRepository.GetByCodeAsync("pl-PL").Result;
        var enLanguage = _languageRepository.GetByCodeAsync("en-GB").Result;

        if (plLanguage != null && enLanguage != null)
        {
            return new List<PaymentTranslation>
            {
                new PaymentTranslation { Language = plLanguage, Name = source.NamePl, Description = source.DescriptionPl },
                new PaymentTranslation { Language = enLanguage, Name = source.NameEn, Description = source.DescriptionEn }
            };
        }

        return default!;
    }
}