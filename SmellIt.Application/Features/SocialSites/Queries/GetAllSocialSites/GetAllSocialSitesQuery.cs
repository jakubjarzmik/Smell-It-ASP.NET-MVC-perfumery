using MediatR;

namespace SmellIt.Application.Features.SocialSites.Queries.GetAllSocialSites
{
    public class GetAllSocialSitesQuery : IRequest<IEnumerable<SocialSiteDto>>
    {
    }
}
