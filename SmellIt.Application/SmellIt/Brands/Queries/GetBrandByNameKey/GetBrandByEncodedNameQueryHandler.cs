using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Brands.Queries.GetBrandByNameKey
{
    public class GetBrandByEncodedNameQueryHandler : IRequestHandler<GetBrandByEncodedNameQuery, BrandDto>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetBrandByEncodedNameQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<BrandDto> Handle(GetBrandByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByEncodedName(request.EncodedName);
            var dto = _mapper.Map<BrandDto>(brand);
            return dto;
        }
    }
}
