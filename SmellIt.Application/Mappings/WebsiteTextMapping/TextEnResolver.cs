using AutoMapper;
using SmellIt.Application.SmellIt.HomeBanners;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.WebsiteTextMapping
{
    internal class TextEnResolver : IValueResolver<WebsiteText, WebsiteTextDto, string>
    {
        private readonly IWebsiteTextTranslationRepository _websiteTextTranslationRepository;

        public TextEnResolver(IWebsiteTextTranslationRepository websiteTextTranslationRepository)
        {
            _websiteTextTranslationRepository = websiteTextTranslationRepository;
        }

        public string Resolve(WebsiteText source, WebsiteTextDto destination, string destMember, ResolutionContext context)
        {
            var translation = _websiteTextTranslationRepository.GetTranslation(source.Id, "en-GB").Result;
            return translation!.Text;
        }
    }
}
