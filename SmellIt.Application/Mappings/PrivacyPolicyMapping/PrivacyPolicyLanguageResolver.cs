using AutoMapper;
using SmellIt.Application.Features.PrivacyPolicies.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.PrivacyPolicyMapping
{
    public class PrivacyPolicyLanguageResolver : IValueResolver<PrivacyPolicyDto, PrivacyPolicy, Language>
    {
        private readonly ILanguageRepository _languageRepository;

        public PrivacyPolicyLanguageResolver(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public Language Resolve(PrivacyPolicyDto source, PrivacyPolicy destination, Language destMember, ResolutionContext context)
        {
            return _languageRepository.GetByCode(source.LanguageCode).Result!;
        }
    }
}
