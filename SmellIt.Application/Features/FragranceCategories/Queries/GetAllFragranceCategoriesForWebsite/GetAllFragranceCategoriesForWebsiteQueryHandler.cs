using AutoMapper;
using MediatR;
using SmellIt.Application.Features.FragranceCategories.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.FragranceCategories.Queries.GetAllFragranceCategoriesForWebsite;
public class GetAllFragranceCategoriesForWebsiteQueryHandler : IRequestHandler<GetAllFragranceCategoriesForWebsiteQuery, IEnumerable<WebsiteFragranceCategoryDto>>
{
    private readonly IFragranceCategoryRepository _fragranceCategoryRepository;
    private readonly IMapper _mapper;

    public GetAllFragranceCategoriesForWebsiteQueryHandler(IFragranceCategoryRepository fragranceCategoryRepository, IMapper mapper)
    {
        _fragranceCategoryRepository = fragranceCategoryRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<WebsiteFragranceCategoryDto>> Handle(GetAllFragranceCategoriesForWebsiteQuery request, CancellationToken cancellationToken)
    {
        var fragranceCategories = await _fragranceCategoryRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<WebsiteFragranceCategoryDto>>(fragranceCategories, opt =>
        {
            opt.Items["LanguageCode"] = request.LanguageCode;
        });
        return dtos;
    }
}
