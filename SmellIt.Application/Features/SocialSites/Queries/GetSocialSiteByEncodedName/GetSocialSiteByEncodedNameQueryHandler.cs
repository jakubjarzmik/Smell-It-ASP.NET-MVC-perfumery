﻿using AutoMapper;
using MediatR;
using SmellIt.Application.Features.SocialSites.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.SocialSites.Queries.GetSocialSiteByEncodedName;

public class GetSocialSiteByEncodedNameQueryHandler : IRequestHandler<GetSocialSiteByEncodedNameQuery, SocialSiteDto>
{
    private readonly ISocialSiteRepository _socialSiteRepository;
    private readonly IMapper _mapper;

    public GetSocialSiteByEncodedNameQueryHandler(ISocialSiteRepository socialSiteRepository, IMapper mapper)
    {
        _socialSiteRepository = socialSiteRepository;
        _mapper = mapper;
    }
    public async Task<SocialSiteDto> Handle(GetSocialSiteByEncodedNameQuery request, CancellationToken cancellationToken)
    {
        var socialSite = await _socialSiteRepository.GetAsync(request.EncodedName);
        var dto = _mapper.Map<SocialSiteDto>(socialSite);
        return dto;
    }
}