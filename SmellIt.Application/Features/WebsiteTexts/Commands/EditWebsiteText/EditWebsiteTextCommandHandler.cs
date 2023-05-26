using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.WebsiteTexts.Commands.EditWebsiteText;
public class EditWebsiteTextCommandHandler : IRequestHandler<EditWebsiteTextCommand>
{
    private readonly IWebsiteTextRepository _websiteTextRepository;

    public EditWebsiteTextCommandHandler(IWebsiteTextRepository websiteTextRepository)
    {
        _websiteTextRepository = websiteTextRepository;
    }
    public async Task<Unit> Handle(EditWebsiteTextCommand request, CancellationToken cancellationToken)
    {
        var websiteText = await _websiteTextRepository.GetByEncodedNameAsync(request.EncodedName);
        websiteText.ModifiedAt = DateTime.Now;

        UpdateTranslations(request, websiteText);

        await _websiteTextRepository.CommitAsync();

        return Unit.Value;
    }

    private void UpdateTranslations(EditWebsiteTextCommand request, WebsiteText websiteText)
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
        }
    }
}
