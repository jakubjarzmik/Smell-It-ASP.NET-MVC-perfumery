using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.SocialSites.Commands.CreateSocialSite;

public class CreateSocialSiteCommandHandler : IRequestHandler<CreateSocialSiteCommand>
{
    private readonly IUserContext _userContext;
    private readonly ISocialSiteRepository _socialSiteRepository;
    private readonly IMapper _mapper;
    public CreateSocialSiteCommandHandler(IUserContext userContext, ISocialSiteRepository socialSiteRepository, IMapper mapper)
    {
        _userContext = userContext;
        _socialSiteRepository = socialSiteRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateSocialSiteCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        var socialSite = _mapper.Map<SocialSite>(request);
        await _socialSiteRepository.CreateAsync(socialSite);
        return Unit.Value;
    }
}