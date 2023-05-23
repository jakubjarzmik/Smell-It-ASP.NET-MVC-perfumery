using MediatR;
using SmellIt.Application.Features.Brands.DTOs;

namespace SmellIt.Application.Features.Brands.Queries.GetBrandByEncodedName
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
