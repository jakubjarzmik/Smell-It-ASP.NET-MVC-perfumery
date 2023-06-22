using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.SocialSites.Commands.EditSocialSite;

public class EditSocialSiteCommandHandler : IRequestHandler<EditSocialSiteCommand>
{
    private readonly ISocialSiteRepository _socialSiteRepository;
    private readonly IUserContext _userContext;

    public EditSocialSiteCommandHandler(ISocialSiteRepository socialSiteRepository, IUserContext userContext)
    {
        _socialSiteRepository = socialSiteRepository;
        _userContext = userContext;
    }
    public async Task<Unit> Handle(EditSocialSiteCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        var socialSite = (await _socialSiteRepository.GetAsync(request.EncodedName))!;
        socialSite.ModifiedAt = DateTime.Now;
        socialSite.ModifiedById = currentUser.Id;

        socialSite.Link = request.Link;

        await _socialSiteRepository.CommitAsync();

        return Unit.Value;
    }
}