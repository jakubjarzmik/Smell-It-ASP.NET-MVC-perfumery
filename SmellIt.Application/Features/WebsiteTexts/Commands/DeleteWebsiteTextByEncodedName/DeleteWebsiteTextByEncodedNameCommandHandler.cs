using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.WebsiteTexts.Commands.DeleteWebsiteTextByEncodedName
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
            await _websiteTextRepository.DeleteByEncodedName(request.EncodedName);
            return Unit.Value;
        }
    }
}
