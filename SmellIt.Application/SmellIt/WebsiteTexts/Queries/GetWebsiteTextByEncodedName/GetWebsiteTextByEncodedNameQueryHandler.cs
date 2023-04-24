using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.WebsiteTexts.Queries.GetWebsiteTextByEncodedName
{
    public class GetWebsiteTextByEncodedNameQueryHandler : IRequestHandler<GetWebsiteTextByEncodedNameQuery, WebsiteTextDto>
    {
        private readonly IWebsiteTextRepository _websiteTextRepository;
        private readonly IMapper _mapper;

        public GetWebsiteTextByEncodedNameQueryHandler(IWebsiteTextRepository websiteTextRepository, IMapper mapper)
        {
            _websiteTextRepository = websiteTextRepository;
            _mapper = mapper;
        }
        public async Task<WebsiteTextDto> Handle(GetWebsiteTextByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var websiteText = await _websiteTextRepository.GetByEncodedName(request.EncodedName);
            var dto = _mapper.Map<WebsiteTextDto>(websiteText);
            return dto;
        }
    }
}
