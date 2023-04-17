using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Brands.Queries.GetBrandByNameKey
{
    public class GetBrandByEncodedNameQueryHandler : IRequestHandler<GetBrandByEncodedNameQuery, BrandDto>
    {
        private readonly IBrandRepository _brandRepository;

        public GetBrandByEncodedNameQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<BrandDto> Handle(GetBrandByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByEncodedName(request.EncodedName);
            var dto = await ConvertToBrandDto(brand!);
            return dto;
        }
        private async Task<BrandDto> ConvertToBrandDto(Brand brand)
        {
            return new BrandDto();
        }
    }
}
