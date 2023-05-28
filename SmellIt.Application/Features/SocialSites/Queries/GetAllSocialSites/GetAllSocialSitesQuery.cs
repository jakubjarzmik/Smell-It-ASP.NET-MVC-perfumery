using MediatR;
using SmellIt.Application.Features.SocialSites.DTOs;

namespace SmellIt.Application.Features.SocialSites.Queries.GetAllSocialSites;

public class GetAllSocialSitesQuery : IRequest<IEnumerable<SocialSiteDto>>
{
}