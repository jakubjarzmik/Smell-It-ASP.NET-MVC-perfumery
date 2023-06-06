using AutoMapper;
using MediatR;
using SmellIt.Application.Features.WebsiteTexts.DTOs;
using SmellIt.Application.ViewModels.Admin;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.WebsiteTexts.Queries.GetPaginatedWebsiteTexts;
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
        var totalWebsiteTexts = await _websiteTextRepository.CountAsync();
        var websiteTexts = await _websiteTextRepository.GetPaginatedAsync(request.PageNumber, request.PageSize);

        var websiteTextDtos = _mapper.Map<IEnumerable<WebsiteTextForAdminDto>>(websiteTexts);

        var viewModel = new WebsiteTextsViewModel(websiteTextDtos, totalWebsiteTexts, request.PageNumber, request.PageSize);

        return viewModel;
    }
}
