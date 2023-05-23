using AutoMapper;
using MediatR;
using SmellIt.Application.Features.HomeBanners.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.HomeBanners.Queries.GetAllHomeBanners;
public class GetAllHomeBannersQueryHandler : IRequestHandler<GetAllHomeBannersQuery, IEnumerable<HomeBannerDto>>
{
	private readonly IHomeBannerRepository _homeBannerRepository;
	private readonly IMapper _mapper;

    public GetAllHomeBannersQueryHandler(IHomeBannerRepository homeBannerRepository, IMapper mapper)
    {
        _homeBannerRepository = homeBannerRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<HomeBannerDto>> Handle(GetAllHomeBannersQuery request, CancellationToken cancellationToken)
    {
        var homeBanners = await _homeBannerRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<HomeBannerDto>>(homeBanners);
        return dtos;
    }
}
