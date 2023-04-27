﻿using AutoMapper;
using SmellIt.Application.SmellIt.FragranceCategories;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.FragranceCategoryMapping
{
    internal class NamePlResolver : IValueResolver<FragranceCategory, FragranceCategoryDto, string>
    {
        private readonly IFragranceCategoryTranslationRepository _fragranceCategoryTranslationRepository;

        public NamePlResolver(IFragranceCategoryTranslationRepository fragranceCategoryTranslationRepository)
        {
            _fragranceCategoryTranslationRepository = fragranceCategoryTranslationRepository;
        }

        public string Resolve(FragranceCategory source, FragranceCategoryDto destination, string destMember, ResolutionContext context)
        {
            var translation = _fragranceCategoryTranslationRepository.GetTranslation(source.Id, "pl-PL").Result;
            return translation!.Name;
        }
    }
}