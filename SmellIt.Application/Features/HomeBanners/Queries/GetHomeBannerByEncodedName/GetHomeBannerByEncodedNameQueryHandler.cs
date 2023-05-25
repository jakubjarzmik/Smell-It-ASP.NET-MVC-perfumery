using AutoMapper;
using MediatR;
using SmellIt.Application.Features.HomeBanners.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.HomeBanners.Queries.GetHomeBannerByEncodedName
{
    public class GetHomeBannerByEncodedNameQueryHandler : IRequestHandler<GetHomeBannerByEncodedNameQuery, HomeBannerDto>
    {
	    private readonly IHomeBannerRepository _homeBannerRepository;
	    private readonly IMapper _mapper;

        public GetHomeBannerByEncodedNameQueryHandler(IHomeBannerRepository homeBannerRepository, IMapper mapper)
        {
            _homeBannerRepository = homeBannerRepository;
            _mapper = mapper;
        }
        public async Task<HomeBannerDto> Handle(GetHomeBannerByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var layoutText = await _homeBannerRepository.GetByEncodedName(request.EncodedName);
            var dto = _mapper.Map<HomeBannerDto>(layoutText);
            return dto;
        }
    }
}
