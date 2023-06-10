using AutoMapper;
using SmellIt.Application.Features.Deliveries.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.DeliveryMapping;
public class DeliveryTranslationsResolver : IValueResolver<DeliveryDto, Delivery, ICollection<DeliveryTranslation>>
{
    private readonly ILanguageRepository _languageRepository;

    public DeliveryTranslationsResolver(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public ICollection<DeliveryTranslation> Resolve(DeliveryDto source, Delivery destination, ICollection<DeliveryTranslation> destMember, ResolutionContext context)
    {
        var plLanguage = _languageRepository.GetByCodeAsync("pl-PL").Result;
        var enLanguage = _languageRepository.GetByCodeAsync("en-GB").Result;

        if (plLanguage != null && enLanguage != null)
        {
            return new List<DeliveryTranslation>
            {
                new DeliveryTranslation { Language = plLanguage, Name = source.NamePl, Description = source.DescriptionPl },
                new DeliveryTranslation { Language = enLanguage, Name = source.NameEn, Description = source.DescriptionEn }
            };
        }

        return default!;
    }
}