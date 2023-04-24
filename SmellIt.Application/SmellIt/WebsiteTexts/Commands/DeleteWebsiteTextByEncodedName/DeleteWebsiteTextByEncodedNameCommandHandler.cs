using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.WebsiteTexts.Commands.DeleteWebsiteTextByEncodedName
{
    public class DeleteWebsiteTextByEncodedNameCommandHandler : IRequestHandler<DeleteWebsiteTextByEncodedNameCommand>
    {
        private readonly IWebsiteTextRepository _websiteTextRepository;
        private readonly IWebsiteTextTranslationRepository _websiteTextTranslationRepository;

        public DeleteWebsiteTextByEncodedNameCommandHandler(IWebsiteTextRepository websiteTextRepository, IWebsiteTextTranslationRepository websiteTextTranslationRepository)
        {
            _websiteTextRepository = websiteTextRepository;
            _websiteTextTranslationRepository = websiteTextTranslationRepository;
        }

        public async Task<Unit> Handle(DeleteWebsiteTextByEncodedNameCommand request, CancellationToken cancellationToken)
        {
            var layoutText = (await _websiteTextRepository.GetByEncodedName(request.EncodedName))!;
            layoutText.IsActive = false;
            layoutText.DeletedAt = DateTime.UtcNow;

            var layoutTextTranslations = await _websiteTextTranslationRepository.GetWebsiteTextTranslations(layoutText.Id);
            foreach (var brandTranslation in layoutTextTranslations)
            {
                brandTranslation.IsActive = false;
                brandTranslation.DeletedAt = DateTime.UtcNow;
            }

            await _websiteTextRepository.Commit();
            return Unit.Value;
        }
    }
}
