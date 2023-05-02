using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.WebsiteTexts.Commands.EditWebsiteText
{
    public class EditWebsiteTextCommandHandler : IRequestHandler<EditWebsiteTextCommand>
    {
        private readonly IWebsiteTextRepository _websiteTextRepository;

        public EditWebsiteTextCommandHandler(IWebsiteTextRepository websiteTextRepository)
        {
            _websiteTextRepository = websiteTextRepository;
        }
        public async Task<Unit> Handle(EditWebsiteTextCommand request, CancellationToken cancellationToken)
        {
            var websiteText = (await _websiteTextRepository.GetByEncodedName(request.EncodedName))!;
            websiteText.ModifiedAt = DateTime.UtcNow;

            var plTranslation = websiteText.WebsiteTextTranslations.First(wtt => wtt.Language.Code == "pl-PL");
            plTranslation.Text = request.TextPl;
            plTranslation.ModifiedAt = DateTime.UtcNow;

            var enTranslation = websiteText.WebsiteTextTranslations.First(wtt => wtt.Language.Code == "en-GB");
            enTranslation.Text = request.TextEn;
            enTranslation.ModifiedAt = DateTime.UtcNow;

            await _websiteTextRepository.Commit();
            
            return Unit.Value;
        }
    }
}
