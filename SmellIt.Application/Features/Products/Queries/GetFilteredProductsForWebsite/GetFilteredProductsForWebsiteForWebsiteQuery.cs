﻿using MediatR;
using SmellIt.Application.Features.Products.DTOs;

public enum SortType
{
    newest,
    oldest,
    price_ascending,
    price_descending
}

namespace SmellIt.Application.Features.Products.Queries.GetFilteredProductsForWebsite
{
    public class GetFilteredProductsForWebsiteQuery : IRequest<IEnumerable<WebsiteProductDto>>
    {
        public SortType? SortType { get; set; }
        public string LanguageCode { get; set; } = "en-GB";
        public string? CategoryEncodedName { get; set; }
        public string? BrandEncodedName { get; set; }
        public string? GenderEncodedName { get; set; }
        public string? FragranceCategoryEncodedName { get; set; }
    }
}
