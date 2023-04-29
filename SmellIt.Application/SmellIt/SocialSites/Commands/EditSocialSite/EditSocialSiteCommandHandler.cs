using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.SocialSites.Commands.EditSocialSite
{
    public class EditSocialSiteCommandHandler : IRequestHandler<EditSocialSiteCommand>
    {
        private readonly ISocialSiteRepository _socialSiteRepository;

        public EditSocialSiteCommandHandler(ISocialSiteRepository socialSiteRepository)
        {
            _socialSiteRepository = socialSiteRepository;
        }
        public async Task<Unit> Handle(EditSocialSiteCommand request, CancellationToken cancellationToken)
        {
            var socialSite = (await _socialSiteRepository.GetByEncodedName(request.EncodedName))!;
            socialSite.ModifiedAt = DateTime.UtcNow;
            socialSite.Link = request.Link;

            await _socialSiteRepository.Commit();

            return Unit.Value;
        }
    }
}
