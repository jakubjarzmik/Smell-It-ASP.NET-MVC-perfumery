﻿using AutoMapper;
using SmellIt.Application.SmellIt.Brands;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.BrandMapping
{
    internal class DescriptionPlResolver : IValueResolver<Brand, BrandDto, string?>
    {
        private readonly IBrandTranslationRepository _brandTranslationRepository;
        private readonly ILanguageRepository _languageRepository;

        public DescriptionPlResolver(IBrandTranslationRepository brandTranslationRepository, ILanguageRepository languageRepository)
        {
            _brandTranslationRepository = brandTranslationRepository;
            _languageRepository = languageRepository;
        }
        public string? Resolve(Brand source, BrandDto destination, string? destMember, ResolutionContext context)
        {
            var languageId = _languageRepository.GetByCode("pl-PL").Result!.Id;
            var translation = _brandTranslationRepository.GetByBrandId(source.Id).Result.FirstOrDefault(t => t.LanguageId == languageId);
            return translation!.Description;
        }
    }
}
