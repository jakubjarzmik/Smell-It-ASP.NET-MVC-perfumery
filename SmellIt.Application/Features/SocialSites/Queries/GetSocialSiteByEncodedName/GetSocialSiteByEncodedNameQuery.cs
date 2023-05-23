using MediatR;

namespace SmellIt.Application.Features.SocialSites.Queries.GetSocialSiteByEncodedName
{
    public class GetSocialSiteByEncodedNameQuery : IRequest<SocialSiteDto>
    {
        public string EncodedName { get; set; }

        public GetSocialSiteByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
