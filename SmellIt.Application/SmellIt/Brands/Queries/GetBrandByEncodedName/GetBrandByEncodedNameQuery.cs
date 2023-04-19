using MediatR;

namespace SmellIt.Application.SmellIt.Brands.Queries.GetBrandByEncodedName
{
    public class GetBrandByEncodedNameQuery : IRequest<BrandDto>
    {
        public string EncodedName { get; set; }

        public GetBrandByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
