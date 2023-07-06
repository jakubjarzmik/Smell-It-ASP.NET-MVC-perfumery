using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.WebsiteTexts.Commands.CreateWebsiteText;

public class CreateWebsiteTextCommandHandler : IRequestHandler<CreateWebsiteTextCommand>
{
    private readonly IUserContext _userContext;
    private readonly IWebsiteTextRepository _websiteTextRepository;
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    public CreateWebsiteTextCommandHandler(IUserContext userContext,IWebsiteTextRepository websiteTextRepository, ILanguageRepository languageRepository, IMapper mapper)
    {
        _userContext = userContext;
        _websiteTextRepository = websiteTextRepository;
        _languageRepository = languageRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateWebsiteTextCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        var plLanguage = await _languageRepository.GetByCodeAsync("pl-PL");
        var enLanguage = await _languageRepository.GetByCodeAsync("en-GB");

        var websiteText = _mapper.Map<WebsiteText>(request);

        if (plLanguage != null && enLanguage != null)
        {
            websiteText.WebsiteTextTranslations = new List<WebsiteTextTranslation>
            {
                new WebsiteTextTranslation { Language = plLanguage, Text = request.TextPl },
                new WebsiteTextTranslation { Language = enLanguage, Text = request.TextEn }
            };
        }

        await _websiteTextRepository.CreateAsync(websiteText);
        return Unit.Value;
    }
}