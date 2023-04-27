using MediatR;

namespace SmellIt.Application.SmellIt.SocialSites.Queries.GetAllSocialSites
{
    public class GetAllSocialSitesQuery : IRequest<IEnumerable<SocialSiteDto>>
    {
    }
}
