using AutoMapper;
using SmellIt.Application.SmellIt.LayoutTexts;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.LayoutTextMapping
{
    internal class TextEnResolver : IValueResolver<LayoutText, LayoutTextDto, string>
    {
        private readonly ILayoutTextTranslationRepository _layoutTextTranslationRepository;

        public TextEnResolver(ILayoutTextTranslationRepository layoutTextTranslationRepository)
        {
            _layoutTextTranslationRepository = layoutTextTranslationRepository;
        }

        public string Resolve(LayoutText source, LayoutTextDto destination, string destMember, ResolutionContext context)
        {
            var translation = _layoutTextTranslationRepository.GetTranslation(source.Id, "en-GB").Result;
            return translation!.Text;
        }
    }
}
