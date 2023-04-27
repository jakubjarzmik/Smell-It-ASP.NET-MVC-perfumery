using AutoMapper;
using MediatR;
using SmellIt.Application.ViewModels;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.HomeBanners.Queries.GetPaginatedHomeBanners;
public class GetPaginatedHomeBannersQueryHandler : IRequestHandler<GetPaginatedHomeBannersQuery, HomeBannersViewModel>
{
	private readonly IHomeBannerRepository _homeBannerRepository;
	private readonly IMapper _mapper;

    public GetPaginatedHomeBannersQueryHandler(IHomeBannerRepository homeBannerRepository, IMapper mapper)
    {
        _homeBannerRepository = homeBannerRepository;
        _mapper = mapper;
    }
    public async Task<HomeBannersViewModel> Handle(GetPaginatedHomeBannersQuery request, CancellationToken cancellationToken)
    {
        var homeBanners = await _homeBannerRepository.GetAll();
        var homeBannerDtos = _mapper.Map<IEnumerable<HomeBannerDto>>(homeBanners);
        
        var paginatedHomeBanners = homeBannerDtos
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        var totalPages = (int)Math.Ceiling((double)homeBannerDtos.Count() / request.PageSize);
        
        var viewModel = new HomeBannersViewModel
        {
            HomeBanners = paginatedHomeBanners,
            CurrentPage = request.PageNumber,
            TotalPages = totalPages,
            PageSize = request.PageSize
        };

        return viewModel;
    }
}
