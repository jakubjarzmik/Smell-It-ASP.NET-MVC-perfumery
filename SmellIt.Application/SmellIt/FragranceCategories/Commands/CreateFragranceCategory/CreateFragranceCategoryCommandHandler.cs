﻿using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.FragranceCategories.Commands.CreateFragranceCategory
{
    public class CreateFragranceCategoryCommandHandler : IRequestHandler<CreateFragranceCategoryCommand>
    {
        private readonly IFragranceCategoryRepository _fragranceCategoryRepository;
        private readonly IMapper _mapper;
        public CreateFragranceCategoryCommandHandler(IFragranceCategoryRepository fragranceCategoryRepository, IMapper mapper)
        {
            _fragranceCategoryRepository = fragranceCategoryRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateFragranceCategoryCommand request, CancellationToken cancellationToken)
        {
            var fragranceCategory = _mapper.Map<FragranceCategory>(request);

            await _fragranceCategoryRepository.Create(fragranceCategory);

            fragranceCategory.EncodeName();
            await _fragranceCategoryRepository.Commit();


            return Unit.Value;
        }
    }
}