using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.WebsiteTexts.Commands.EditWebsiteText
{
    public class EditWebsiteTextCommandHandler : IRequestHandler<EditWebsiteTextCommand>
    {
        private readonly IWebsiteTextRepository _websiteTextRepository;
        private readonly IWebsiteTextTranslationRepository _websiteTextTranslationRepository;

        public EditWebsiteTextCommandHandler(IWebsiteTextRepository websiteTextRepository, IWebsiteTextTranslationRepository websiteTextTranslationRepository)
        {
            _websiteTextRepository = websiteTextRepository;
            _websiteTextTranslationRepository = websiteTextTranslationRepository;
        }
        public async Task<Unit> Handle(EditWebsiteTextCommand request, CancellationToken cancellationToken)
        {
            var websiteText = (await _websiteTextRepository.GetByEncodedName(request.EncodedName))!;
            websiteText.ModifiedAt = DateTime.UtcNow;

            var plTranslation = (await _websiteTextTranslationRepository.GetTranslation(websiteText.Id, "pl-PL"))!;
            plTranslation.Text = request.TextPL;
            plTranslation.ModifiedAt = DateTime.UtcNow;

            var enTranslation = (await _websiteTextTranslationRepository.GetTranslation(websiteText.Id, "en-GB"))!;
            enTranslation.Text = request.TextEN;
            enTranslation.ModifiedAt = DateTime.UtcNow;

            await _websiteTextRepository.Commit();
            
            return Unit.Value;
        }
    }
}
