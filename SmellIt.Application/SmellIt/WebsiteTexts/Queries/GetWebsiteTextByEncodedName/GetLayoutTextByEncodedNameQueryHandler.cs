using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.WebsiteTexts.Queries.GetWebsiteTextByEncodedName
{
    public class GetLayoutTextByEncodedNameQueryHandler : IRequestHandler<GetWebsiteTextByEncodedNameQuery, WebsiteTextDto>
    {
        private readonly IWebsiteTextRepository _websiteTextRepository;
        private readonly IMapper _mapper;

        public GetLayoutTextByEncodedNameQueryHandler(IWebsiteTextRepository websiteTextRepository, IMapper mapper)
        {
            _websiteTextRepository = websiteTextRepository;
            _mapper = mapper;
        }
        public async Task<WebsiteTextDto> Handle(GetWebsiteTextByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var layoutText = await _websiteTextRepository.GetByEncodedName(request.EncodedName);
            var dto = _mapper.Map<WebsiteTextDto>(layoutText);
            return dto;
        }
    }
}
