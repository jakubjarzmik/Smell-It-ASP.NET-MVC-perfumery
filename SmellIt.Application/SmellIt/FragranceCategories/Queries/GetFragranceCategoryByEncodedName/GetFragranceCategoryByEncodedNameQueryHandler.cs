﻿using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.FragranceCategories.Queries.GetFragranceCategoryByEncodedName
{
    public class GetBrandByEncodedNameQueryHandler : IRequestHandler<GetFragranceCategoryByEncodedNameQuery, FragranceCategoryDto>
    {
        private readonly IFragranceCategoryRepository _fragranceCategoryRepository;
        private readonly IMapper _mapper;

        public GetBrandByEncodedNameQueryHandler(IFragranceCategoryRepository fragranceCategoryRepository, IMapper mapper)
        {
            _fragranceCategoryRepository = fragranceCategoryRepository;
            _mapper = mapper;
        }
        public async Task<FragranceCategoryDto> Handle(GetFragranceCategoryByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var fragranceCategory = await _fragranceCategoryRepository.GetByEncodedName(request.EncodedName);
            var dto = _mapper.Map<FragranceCategoryDto>(fragranceCategory);
            return dto;
        }
    }
}
