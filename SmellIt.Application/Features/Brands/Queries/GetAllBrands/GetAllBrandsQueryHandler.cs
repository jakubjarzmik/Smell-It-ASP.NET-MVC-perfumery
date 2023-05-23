using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Brands.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Brands.Queries.GetAllBrands;
public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, IEnumerable<BrandDto>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetAllBrandsQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<BrandDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await _brandRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<BrandDto>>(brands);
        return dtos;
    }
}
