using AutoMapper;
using MediatR;
using SmellIt.Application.Features.WebsiteTexts.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.WebsiteTexts.Queries.GetAllWebsiteTexts;
public class GetAllWebsiteTextsQueryHandler : IRequestHandler<GetAllWebsiteTextsQuery, IEnumerable<WebsiteTextForAdminDto>>
{
    private readonly IWebsiteTextRepository _websiteTextRepository;
    private readonly IMapper _mapper;

    public GetAllWebsiteTextsQueryHandler(IWebsiteTextRepository websiteTextRepository, IMapper mapper)
    {
        _websiteTextRepository = websiteTextRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<WebsiteTextForAdminDto>> Handle(GetAllWebsiteTextsQuery request, CancellationToken cancellationToken)
    {
        var layoutTexts = await _websiteTextRepository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<WebsiteTextForAdminDto>>(layoutTexts);
        return dtos;
    }
}
