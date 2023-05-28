using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.SocialSites.Commands.DeleteSocialSiteByEncodedName;

public class DeleteSocialSiteByEncodedNameCommandHandler : IRequestHandler<DeleteSocialSiteByEncodedNameCommand>
{
    private readonly ISocialSiteRepository _socialSiteRepository;

    public DeleteSocialSiteByEncodedNameCommandHandler(ISocialSiteRepository socialSiteRepository)
    {
        _socialSiteRepository = socialSiteRepository;
    }

    public async Task<Unit> Handle(DeleteSocialSiteByEncodedNameCommand request, CancellationToken cancellationToken)
    {
        await _socialSiteRepository.DeleteByEncodedNameAsync(request.EncodedName);
        return Unit.Value;
    }
}