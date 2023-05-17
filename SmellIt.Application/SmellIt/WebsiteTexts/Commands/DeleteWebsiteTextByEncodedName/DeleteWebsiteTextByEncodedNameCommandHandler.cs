using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.WebsiteTexts.Commands.DeleteWebsiteTextByEncodedName
{
    public class DeleteWebsiteTextByEncodedNameCommandHandler : IRequestHandler<DeleteWebsiteTextByEncodedNameCommand>
    {
        private readonly IWebsiteTextRepository _websiteTextRepository;

        public DeleteWebsiteTextByEncodedNameCommandHandler(IWebsiteTextRepository websiteTextRepository)
        {
            _websiteTextRepository = websiteTextRepository;
        }

        public async Task<Unit> Handle(DeleteWebsiteTextByEncodedNameCommand request, CancellationToken cancellationToken)
        {
            var websiteText = (await _websiteTextRepository.GetByEncodedName(request.EncodedName))!;
            websiteText.IsActive = false;
            websiteText.DeletedAt = DateTime.Now;

            foreach (var websiteTextTranslation in websiteText.WebsiteTextTranslations)
            {
                websiteTextTranslation.IsActive = false;
                websiteTextTranslation.DeletedAt = DateTime.Now;
            }

            await _websiteTextRepository.Commit();
            return Unit.Value;
        }
    }
}
