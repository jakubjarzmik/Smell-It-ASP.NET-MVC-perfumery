using AutoMapper;
using MediatR;
using SmellIt.Application.ViewModels;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.FragranceCategories.Queries.GetPaginatedFragranceCategories;
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
        var fragranceCategories = await _fragranceCategoryRepository.GetAll();
        var fragranceCategoryDtos = _mapper.Map<IEnumerable<FragranceCategoryDto>>(fragranceCategories);
        
        var paginatedFragranceCategories = fragranceCategoryDtos
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        var totalPages = (int)Math.Ceiling((double)fragranceCategoryDtos.Count() / request.PageSize);
        
        var viewModel = new FragranceCategoriesViewModel
        {
            FragranceCategories = paginatedFragranceCategories,
            CurrentPage = request.PageNumber,
            TotalPages = totalPages,
            PageSize = request.PageSize
        };

        return viewModel;
    }
}
