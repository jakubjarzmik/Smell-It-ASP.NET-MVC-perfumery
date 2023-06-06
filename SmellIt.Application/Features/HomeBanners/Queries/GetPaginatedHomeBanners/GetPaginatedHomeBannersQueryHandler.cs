using AutoMapper;
using MediatR;
using SmellIt.Application.Features.HomeBanners.DTOs;
using SmellIt.Application.ViewModels.Admin;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.HomeBanners.Queries.GetPaginatedHomeBanners;
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
        var totalHomeBanners = await _homeBannerRepository.CountAsync();
        var homeBanners = await _homeBannerRepository.GetPaginatedAsync(request.PageNumber, request.PageSize);

        var homeBannerDtos = _mapper.Map<IEnumerable<HomeBannerDto>>(homeBanners);

        var viewModel = new HomeBannersViewModel(homeBannerDtos, totalHomeBanners, request.PageNumber, request.PageSize);

        return viewModel;
    }
}
