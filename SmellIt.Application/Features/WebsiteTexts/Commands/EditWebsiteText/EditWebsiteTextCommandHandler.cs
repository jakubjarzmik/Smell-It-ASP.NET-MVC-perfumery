using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.WebsiteTexts.Commands.EditWebsiteText;
public class EditWebsiteTextCommandHandler : IRequestHandler<EditWebsiteTextCommand>
{
    private readonly IWebsiteTextRepository _websiteTextRepository;
    private readonly IUserContext _userContext;

    public EditWebsiteTextCommandHandler(IWebsiteTextRepository websiteTextRepository, IUserContext userContext)
    {
        _websiteTextRepository = websiteTextRepository;
        _userContext = userContext;
    }
    public async Task<Unit> Handle(EditWebsiteTextCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        var websiteText = await _websiteTextRepository.GetAsync(request.EncodedName);

        if(websiteText == null) return Unit.Value;

        websiteText.ModifiedAt = DateTime.Now;
        websiteText.ModifiedById = currentUser.Id;

        UpdateTranslations(request, websiteText, currentUser.Id);

        await _websiteTextRepository.CommitAsync();

        return Unit.Value;
    }

    private void UpdateTranslations(EditWebsiteTextCommand request, WebsiteText websiteText, string currentUserId)
    {
        var translations = new Dictionary<string, string>
            {
                { "pl-PL", request.TextPl },
                { "en-GB", request.TextEn }
            };

        foreach (var translation in translations)
        {
            var websiteTextTranslation = websiteText.WebsiteTextTranslations.First(wtt => wtt.Language.Code == translation.Key);
            websiteTextTranslation.Text = translation.Value;
            websiteTextTranslation.ModifiedAt = DateTime.Now;
            websiteTextTranslation.ModifiedById = currentUserId;
        }
    }
}
