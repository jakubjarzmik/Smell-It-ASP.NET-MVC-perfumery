using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.SocialSites.Commands.CreateSocialSite
{
    public class CreateSocialSiteCommandHandler : IRequestHandler<CreateSocialSiteCommand>
    {
        private readonly ISocialSiteRepository _socialSiteRepository;
        private readonly IMapper _mapper;
        public CreateSocialSiteCommandHandler(ISocialSiteRepository socialSiteRepository, IMapper mapper)
        {
            _socialSiteRepository = socialSiteRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateSocialSiteCommand request, CancellationToken cancellationToken)
        {
            var socialSite = _mapper.Map<SocialSite>(request);
            await _socialSiteRepository.CreateAsync(socialSite);
            return Unit.Value;
        }
    }
}
