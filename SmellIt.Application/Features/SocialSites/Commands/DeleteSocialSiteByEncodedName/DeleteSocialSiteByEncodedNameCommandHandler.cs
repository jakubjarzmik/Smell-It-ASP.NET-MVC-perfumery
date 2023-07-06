using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.SocialSites.Commands.DeleteSocialSiteByEncodedName;

public class DeleteSocialSiteByEncodedNameCommandHandler : IRequestHandler<DeleteSocialSiteByEncodedNameCommand>
{
    private readonly IUserContext _userContext;
    private readonly ISocialSiteRepository _socialSiteRepository;

    public DeleteSocialSiteByEncodedNameCommandHandler(IUserContext userContext, ISocialSiteRepository socialSiteRepository)
    {
        _userContext = userContext;
        _socialSiteRepository = socialSiteRepository;
    }

    public async Task<Unit> Handle(DeleteSocialSiteByEncodedNameCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        await _socialSiteRepository.DeleteAsync(request.EncodedName);
        return Unit.Value;
    }
}