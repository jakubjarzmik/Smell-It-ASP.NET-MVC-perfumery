using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.WebsiteTexts.Commands.CreateWebsiteText
{
    public class CreateWebsiteTextCommandHandler : IRequestHandler<CreateWebsiteTextCommand>
    {
        private readonly IWebsiteTextRepository _websiteTextRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        public CreateWebsiteTextCommandHandler(IWebsiteTextRepository websiteTextRepository,ILanguageRepository languageRepository, IMapper mapper)
        {
            _websiteTextRepository = websiteTextRepository;
            _languageRepository = languageRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateWebsiteTextCommand request, CancellationToken cancellationToken)
        {
            var websiteText = _mapper.Map<WebsiteText>(request);
            websiteText.EncodeName();

            foreach (var translation in websiteText.WebsiteTextTranslations!)
            {
                translation.WebsiteText = websiteText;
                if (translation.Text == request.TextPL)
                    translation.Language = (await _languageRepository.GetByCode("pl-PL"))!;
                else if (translation.Text == request.TextEN)
                    translation.Language = (await _languageRepository.GetByCode("en-GB"))!;
                translation.EncodeName();
            }

            await _websiteTextRepository.Create(websiteText);

            return Unit.Value;
        }
    }
}
