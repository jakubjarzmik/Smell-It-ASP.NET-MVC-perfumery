using MediatR;
using SmellIt.Application.Features.WebsiteTexts.DTOs;

namespace SmellIt.Application.Features.WebsiteTexts.Queries.GetWebsiteTextByEncodedName
{
    public class GetWebsiteTextByEncodedNameQuery : IRequest<WebsiteTextForAdminDto>
    {
        public string EncodedName { get; set; }

        public GetWebsiteTextByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
