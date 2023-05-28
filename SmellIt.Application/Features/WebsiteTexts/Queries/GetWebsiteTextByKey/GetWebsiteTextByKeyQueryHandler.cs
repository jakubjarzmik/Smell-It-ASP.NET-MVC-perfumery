using AutoMapper;
using MediatR;
using SmellIt.Application.Features.WebsiteTexts.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.WebsiteTexts.Queries.GetWebsiteTextByKey;

public class GetWebsiteTextByKeyQueryHandler : IRequestHandler<GetWebsiteTextByKeyQuery, WebsiteTextDto>
{
    private readonly IWebsiteTextRepository _websiteTextRepository;
    private readonly IMapper _mapper;

    public GetWebsiteTextByKeyQueryHandler(IWebsiteTextRepository websiteTextRepository, IMapper mapper)
    {
        _websiteTextRepository = websiteTextRepository;
        _mapper = mapper;
    }
    public async Task<WebsiteTextDto> Handle(GetWebsiteTextByKeyQuery request, CancellationToken cancellationToken)
    {
        var websiteText = await _websiteTextRepository.GetByKeyAsync(request.Key);
        var dto = _mapper.Map<WebsiteTextDto>(websiteText, opt =>
        {
            opt.Items["LanguageCode"] = request.LanguageCode;
        });
        return dto;
    }
}