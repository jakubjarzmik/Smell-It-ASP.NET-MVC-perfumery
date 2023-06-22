using AutoMapper;
using MediatR;
using SmellIt.Application.Features.WebsiteTexts.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.WebsiteTexts.Queries.GetWebsiteTextByEncodedName;

public class GetWebsiteTextByEncodedNameQueryHandler : IRequestHandler<GetWebsiteTextByEncodedNameQuery, WebsiteTextForAdminDto>
{
    private readonly IWebsiteTextRepository _websiteTextRepository;
    private readonly IMapper _mapper;

    public GetWebsiteTextByEncodedNameQueryHandler(IWebsiteTextRepository websiteTextRepository, IMapper mapper)
    {
        _websiteTextRepository = websiteTextRepository;
        _mapper = mapper;
    }
    public async Task<WebsiteTextForAdminDto> Handle(GetWebsiteTextByEncodedNameQuery request, CancellationToken cancellationToken)
    {
        var websiteText = await _websiteTextRepository.GetAsync(request.EncodedName);
        var dto = _mapper.Map<WebsiteTextForAdminDto>(websiteText);
        return dto;
    }
}