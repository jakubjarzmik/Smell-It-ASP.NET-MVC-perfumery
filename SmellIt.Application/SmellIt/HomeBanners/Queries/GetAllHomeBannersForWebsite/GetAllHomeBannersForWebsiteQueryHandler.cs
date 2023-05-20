using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.HomeBanners.Queries.GetAllHomeBannersForWebsite;
public class GetAllHomeBannersForWebsiteQueryHandler : IRequestHandler<GetAllHomeBannersForWebsiteQuery, IEnumerable<WebsiteHomeBannerDto>>
{
	private readonly IHomeBannerRepository _homeBannerRepository;
	private readonly IMapper _mapper;

    public GetAllHomeBannersForWebsiteQueryHandler(IHomeBannerRepository homeBannerRepository, IMapper mapper)
    {
        _homeBannerRepository = homeBannerRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<WebsiteHomeBannerDto>> Handle(GetAllHomeBannersForWebsiteQuery request, CancellationToken cancellationToken)
    {
        var homeBanners = await _homeBannerRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<WebsiteHomeBannerDto>>(homeBanners, opt =>
        {
            opt.Items["LanguageCode"] = request.LanguageCode;
        });
        return dtos;
    }
}
