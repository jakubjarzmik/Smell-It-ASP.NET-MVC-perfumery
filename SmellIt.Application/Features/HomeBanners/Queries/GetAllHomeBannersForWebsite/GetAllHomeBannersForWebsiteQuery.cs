﻿using MediatR;
using SmellIt.Application.Features.HomeBanners.DTOs;

namespace SmellIt.Application.Features.HomeBanners.Queries.GetAllHomeBannersForWebsite;
public class GetAllHomeBannersForWebsiteQuery : IRequest<IEnumerable<WebsiteHomeBannerDto>>
{
    public string LanguageCode { get; private set; }

    public GetAllHomeBannersForWebsiteQuery(string languageCode)
    {
        LanguageCode = languageCode;
    }
}