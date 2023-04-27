using AutoMapper;
using SmellIt.Application.SmellIt.Languages;
using SmellIt.Application.SmellIt.PrivacyPolicies;
using SmellIt.Application.SmellIt.WebsiteTexts;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.PrivacyPolicyMapping
{
    internal class LanguageResolver : IValueResolver<PrivacyPolicyDto, PrivacyPolicy, Language>
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageResolver(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public Language Resolve(PrivacyPolicyDto source, PrivacyPolicy destination, Language destMember, ResolutionContext context)
        {
            return _languageRepository.GetByCode(source.LanguageCode).Result!;
        }
    }
}
