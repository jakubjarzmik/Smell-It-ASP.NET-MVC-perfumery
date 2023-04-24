using AutoMapper;
using SmellIt.Application.SmellIt.WebsiteTexts;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.WebsiteTextMapping
{
    internal class TextPlResolver : IValueResolver<WebsiteText, WebsiteTextDto, string>
    {
        private readonly IWebsiteTextTranslationRepository _websiteTextTranslationRepository;

        public TextPlResolver(IWebsiteTextTranslationRepository websiteTextTranslationRepository)
        {
            _websiteTextTranslationRepository = websiteTextTranslationRepository;
        }

        public string Resolve(WebsiteText source, WebsiteTextDto destination, string destMember, ResolutionContext context)
        {
            var translation = _websiteTextTranslationRepository.GetTranslation(source.Id, "pl-PL").Result;
            return translation!.Text;
        }
    }
}