using AutoMapper;
using MediatR;
using SmellIt.Application.Features.FragranceCategories.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.FragranceCategories.Queries.GetFragranceCategoryByEncodedName;

public class GetFragranceCategoryByEncodedNameQueryHandler : IRequestHandler<GetFragranceCategoryByEncodedNameQuery, FragranceCategoryDto>
{
    private readonly IFragranceCategoryRepository _fragranceCategoryRepository;
    private readonly IMapper _mapper;

    public GetFragranceCategoryByEncodedNameQueryHandler(IFragranceCategoryRepository fragranceCategoryRepository, IMapper mapper)
    {
        _fragranceCategoryRepository = fragranceCategoryRepository;
        _mapper = mapper;
    }
    public async Task<FragranceCategoryDto> Handle(GetFragranceCategoryByEncodedNameQuery request, CancellationToken cancellationToken)
    {
        var fragranceCategory = await _fragranceCategoryRepository.GetAsync(request.EncodedName);
        var dto = _mapper.Map<FragranceCategoryDto>(fragranceCategory);
        return dto;
    }
}