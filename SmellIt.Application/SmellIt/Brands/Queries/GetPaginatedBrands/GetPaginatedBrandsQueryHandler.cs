using AutoMapper;
using MediatR;
using SmellIt.Application.ViewModels;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Brands.Queries.GetPaginatedBrands;
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
        var brands = await _brandRepository.GetAll();
        var brandDtos = _mapper.Map<IEnumerable<BrandDto>>(brands);
        
        var paginatedBrands = brandDtos
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        var totalPages = (int)Math.Ceiling((double)brandDtos.Count() / request.PageSize);
        
        var viewModel = new BrandsViewModel
        {
            Brands = paginatedBrands,
            CurrentPage = request.PageNumber,
            TotalPages = totalPages,
            PageSize = request.PageSize
        };

        return viewModel;
    }
}
