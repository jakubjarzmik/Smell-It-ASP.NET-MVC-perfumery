using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.WebsiteTexts.Queries.GetAllWebsiteTexts;
public class GetAllWebsiteTextsQueryHandler : IRequestHandler<GetAllWebsiteTextsQuery, IEnumerable<WebsiteTextDto>>
{
    private readonly IWebsiteTextRepository _websiteTextRepository;
    private readonly IMapper _mapper;

    public GetAllWebsiteTextsQueryHandler(IWebsiteTextRepository websiteTextRepository, IMapper mapper)
    {
        _websiteTextRepository = websiteTextRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<WebsiteTextDto>> Handle(GetAllWebsiteTextsQuery request, CancellationToken cancellationToken)
    {
        var layoutTexts = await _websiteTextRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<WebsiteTextDto>>(layoutTexts);
        return dtos;
    }
}
