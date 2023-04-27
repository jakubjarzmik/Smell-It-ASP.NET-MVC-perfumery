using AutoMapper;
using SmellIt.Application.SmellIt.Languages;
using SmellIt.Application.SmellIt.PrivacyPolicies;
using SmellIt.Application.SmellIt.WebsiteTexts;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.PrivacyPolicyMapping
{
    internal class LanguageCodeResolver : IValueResolver<PrivacyPolicy, PrivacyPolicyDto, string>
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageCodeResolver(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public string Resolve(PrivacyPolicy source, PrivacyPolicyDto destination, string destMember, ResolutionContext context)
        {
            return _languageRepository.GetAll().Result.FirstOrDefault(l=>l.Id == source.LanguageId)!.Code;
        }
    }
}
