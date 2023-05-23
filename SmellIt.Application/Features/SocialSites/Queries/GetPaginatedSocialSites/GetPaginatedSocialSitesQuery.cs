using MediatR;
using SmellIt.Application.ViewModels;

namespace SmellIt.Application.Features.SocialSites.Queries.GetPaginatedSocialSites
{
    public class GetPaginatedSocialSitesQuery : IRequest<SocialSitesViewModel>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetPaginatedSocialSitesQuery(int? pageNumber, int pageSize)
        {
            PageNumber = pageNumber ?? 1;
            PageSize = pageSize;
        }
    }
}
