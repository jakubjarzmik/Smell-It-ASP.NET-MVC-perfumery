using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.SocialSites.Queries.GetAllSocialSites;
public class GetAllSocialSitesQueryHandler : IRequestHandler<GetAllSocialSitesQuery, IEnumerable<SocialSiteDto>>
{
    private readonly ISocialSiteRepository _socialSiteRepository;
    private readonly IMapper _mapper;

    public GetAllSocialSitesQueryHandler(ISocialSiteRepository socialSiteRepository, IMapper mapper)
    {
        _socialSiteRepository = socialSiteRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<SocialSiteDto>> Handle(GetAllSocialSitesQuery request, CancellationToken cancellationToken)
    {
        var socialSites = await _socialSiteRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<SocialSiteDto>>(socialSites);
        return dtos;
    }
}
