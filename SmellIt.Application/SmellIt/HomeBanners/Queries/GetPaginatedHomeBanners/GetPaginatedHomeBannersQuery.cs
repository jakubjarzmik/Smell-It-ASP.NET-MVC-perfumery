﻿using MediatR;
using SmellIt.Application.ViewModels;

namespace SmellIt.Application.SmellIt.HomeBanners.Queries.GetPaginatedHomeBanners
{
    public class GetPaginatedHomeBannersQuery : IRequest<HomeBannersViewModel>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetPaginatedHomeBannersQuery(int? pageNumber, int pageSize)
        {
            PageNumber = pageNumber ?? 1;
            PageSize = pageSize;
        }
    }
}
