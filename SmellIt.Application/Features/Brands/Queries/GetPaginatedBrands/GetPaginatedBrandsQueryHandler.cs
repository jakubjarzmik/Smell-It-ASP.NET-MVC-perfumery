using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Brands.DTOs;
using SmellIt.Application.ViewModels.Admin;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Brands.Queries.GetPaginatedBrands;
public class GetPaginatedBrandsQueryHandler : IRequestHandler<GetPaginatedBrandsQuery, BrandsViewModel>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetPaginatedBrandsQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }
    public async Task<BrandsViewModel> Handle(GetPaginatedBrandsQuery request, CancellationToken cancellationToken)
    {
        var totalBrands = await _brandRepository.CountAsync();
        var brands = await _brandRepository.GetPaginatedAsync(request.PageNumber, request.PageSize);

        var brandDtos = _mapper.Map<IEnumerable<BrandDto>>(brands);

        var viewModel = new BrandsViewModel(brandDtos, totalBrands, request.PageNumber, request.PageSize);

        return viewModel;
    }
}
