﻿using SmellIt.Application.SmellIt.Brands;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.ViewModels
{
    public class BrandsViewModel
    {
        public IEnumerable<BrandDto>? Brands { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}
