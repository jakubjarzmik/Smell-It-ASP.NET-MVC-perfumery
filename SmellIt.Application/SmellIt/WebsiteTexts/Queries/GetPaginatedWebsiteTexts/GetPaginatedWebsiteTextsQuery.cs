using MediatR;
using SmellIt.Application.ViewModels;

namespace SmellIt.Application.SmellIt.WebsiteTexts.Queries.GetPaginatedWebsiteTexts
{
    public class GetPaginatedWebsiteTextsQuery : IRequest<WebsiteTextsViewModel>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetPaginatedWebsiteTextsQuery(int? pageNumber, int pageSize)
        {
            PageNumber = pageNumber ?? 1;
            PageSize = pageSize;
        }
    }
}
