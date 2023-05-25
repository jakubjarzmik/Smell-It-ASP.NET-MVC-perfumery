using AutoMapper;
using MediatR;
using SmellIt.Application.Features.FragranceCategories.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.FragranceCategories.Queries.GetAllFragranceCategories;
public class GetAllFragranceCategoriesQueryHandler : IRequestHandler<GetAllFragranceCategoriesQuery, IEnumerable<FragranceCategoryDto>>
{
    private readonly IFragranceCategoryRepository _fragranceCategoryRepository;
    private readonly IMapper _mapper;

    public GetAllFragranceCategoriesQueryHandler(IFragranceCategoryRepository fragranceCategoryRepository, IMapper mapper)
    {
        _fragranceCategoryRepository = fragranceCategoryRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<FragranceCategoryDto>> Handle(GetAllFragranceCategoriesQuery request, CancellationToken cancellationToken)
    {
        var fragranceCategories = await _fragranceCategoryRepository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<FragranceCategoryDto>>(fragranceCategories);
        return dtos;
    }
}
