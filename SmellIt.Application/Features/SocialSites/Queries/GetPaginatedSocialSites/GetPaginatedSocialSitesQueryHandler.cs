using AutoMapper;
using MediatR;
using SmellIt.Application.Features.SocialSites.DTOs;
using SmellIt.Application.ViewModels;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.SocialSites.Queries.GetPaginatedSocialSites;
public class GetPaginatedSocialSitesQueryHandler : IRequestHandler<GetPaginatedSocialSitesQuery, SocialSitesViewModel>
{
    private readonly ISocialSiteRepository _socialSiteRepository;
    private readonly IMapper _mapper;

    public GetPaginatedSocialSitesQueryHandler(ISocialSiteRepository socialSiteRepository, IMapper mapper)
    {
        _socialSiteRepository = socialSiteRepository;
        _mapper = mapper;
    }
    public async Task<SocialSitesViewModel> Handle(GetPaginatedSocialSitesQuery request, CancellationToken cancellationToken)
    {
        var totalSocialSites = await _socialSiteRepository.CountAsync();
        var socialSites = await _socialSiteRepository.GetPaginatedAsync(request.PageNumber, request.PageSize);

        var socialSiteDtos = _mapper.Map<IEnumerable<SocialSiteDto>>(socialSites);

        var viewModel = new SocialSitesViewModel(socialSiteDtos, totalSocialSites, request.PageNumber, request.PageSize);

        return viewModel;
    }
}
