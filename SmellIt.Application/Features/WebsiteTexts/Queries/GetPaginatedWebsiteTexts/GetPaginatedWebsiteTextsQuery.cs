using MediatR;
using SmellIt.Application.ViewModels.Admin;

namespace SmellIt.Application.Features.WebsiteTexts.Queries.GetPaginatedWebsiteTexts;

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