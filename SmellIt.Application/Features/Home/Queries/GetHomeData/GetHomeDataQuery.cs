using MediatR;
using SmellIt.Application.ViewModels.Admin;

namespace SmellIt.Application.Features.Home.Queries.GetHomeData;

public class GetHomeDataQuery : IRequest<HomeViewModel>
{
    public string LanguageCode { get; private set; }

    public GetHomeDataQuery(string languageCode)
    {
        LanguageCode = languageCode;
    }
}