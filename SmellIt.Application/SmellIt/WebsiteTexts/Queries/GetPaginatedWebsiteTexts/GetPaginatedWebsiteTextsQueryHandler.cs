using AutoMapper;
using MediatR;
using SmellIt.Application.ViewModels;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.WebsiteTexts.Queries.GetPaginatedWebsiteTexts;
public class GetPaginatedWebsiteTextsQueryHandler : IRequestHandler<GetPaginatedWebsiteTextsQuery, WebsiteTextsViewModel>
{
    private readonly IWebsiteTextRepository _websiteTextRepository;
    private readonly IMapper _mapper;

    public GetPaginatedWebsiteTextsQueryHandler(IWebsiteTextRepository websiteTextRepository, IMapper mapper)
    {
        _websiteTextRepository = websiteTextRepository;
        _mapper = mapper;
    }
    public async Task<WebsiteTextsViewModel> Handle(GetPaginatedWebsiteTextsQuery request, CancellationToken cancellationToken)
    {
        var websiteTexts = await _websiteTextRepository.GetAll();
        var websiteTextDtos = _mapper.Map<IEnumerable<WebsiteTextDto>>(websiteTexts);
        
        var paginatedWebsiteTexts = websiteTextDtos
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        var totalPages = (int)Math.Ceiling((double)websiteTextDtos.Count() / request.PageSize);
        
        var viewModel = new WebsiteTextsViewModel
        {
            Items = paginatedWebsiteTexts,
            CurrentPage = request.PageNumber,
            TotalPages = totalPages,
            PageSize = request.PageSize
        };

        return viewModel;
    }
}
