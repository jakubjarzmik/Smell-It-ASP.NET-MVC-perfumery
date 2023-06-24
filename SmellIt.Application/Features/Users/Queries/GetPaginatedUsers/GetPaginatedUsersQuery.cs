using MediatR;
using SmellIt.Application.ViewModels.Admin;

namespace SmellIt.Application.Features.Users.Queries.GetPaginatedUsers;

public class GetPaginatedUsersQuery : IRequest<UsersViewModel>
{
    public string LanguageCode { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetPaginatedUsersQuery(string languageCode, int? pageNumber, int pageSize)
    {
        LanguageCode = languageCode;
        PageNumber = pageNumber ?? 1;
        PageSize = pageSize;
    }
}