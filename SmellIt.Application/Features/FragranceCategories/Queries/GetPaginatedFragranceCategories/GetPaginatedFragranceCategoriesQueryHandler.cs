using AutoMapper;
using MediatR;
using SmellIt.Application.Features.FragranceCategories.DTOs;
using SmellIt.Application.ViewModels.Admin;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.FragranceCategories.Queries.GetPaginatedFragranceCategories;
public class GetPaginatedFragranceCategoriesQueryHandler : IRequestHandler<GetPaginatedFragranceCategoriesQuery, FragranceCategoriesViewModel>
{
    private readonly IFragranceCategoryRepository _fragranceCategoryRepository;
    private readonly IMapper _mapper;

    public GetPaginatedFragranceCategoriesQueryHandler(IFragranceCategoryRepository fragranceCategoryRepository, IMapper mapper)
    {
        _fragranceCategoryRepository = fragranceCategoryRepository;
        _mapper = mapper;
    }
    public async Task<FragranceCategoriesViewModel> Handle(GetPaginatedFragranceCategoriesQuery request, CancellationToken cancellationToken)
    {
        var totalFragranceCategories = await _fragranceCategoryRepository.CountAsync();
        var fragranceCategories = await _fragranceCategoryRepository.GetPaginatedAsync(request.PageNumber, request.PageSize);

        var fragranceCategoryDtos = _mapper.Map<IEnumerable<FragranceCategoryDto>>(fragranceCategories);

        var viewModel = new FragranceCategoriesViewModel(fragranceCategoryDtos, totalFragranceCategories, request.PageNumber, request.PageSize);

        return viewModel;
    }
}
