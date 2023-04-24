using MediatR;

namespace SmellIt.Application.SmellIt.HomeBanners.Queries.GetHomeBannerByEncodedName
{
    public class GetHomeBannerByEncodedNameQuery : IRequest<HomeBannerDto>
    {
        public string EncodedName { get; set; }

        public GetHomeBannerByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
