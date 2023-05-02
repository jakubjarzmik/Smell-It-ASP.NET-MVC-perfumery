using AutoMapper;
using MediatR;
using SmellIt.Application.ViewModels;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.SocialSites.Queries.GetPaginatedSocialSites;
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
        var socialSites = await _socialSiteRepository.GetAll();
        var socialSiteDtos = _mapper.Map<IEnumerable<SocialSiteDto>>(socialSites);
        
        var paginatedSocialSites = socialSiteDtos
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        var totalPages = (int)Math.Ceiling((double)socialSiteDtos.Count() / request.PageSize);
        
        var viewModel = new SocialSitesViewModel
        {
            Items = paginatedSocialSites,
            CurrentPage = request.PageNumber,
            TotalPages = totalPages,
            PageSize = request.PageSize
        };

        return viewModel;
    }
}
