using AutoMapper;
using MediatR;
using SmellIt.Application.SmellIt.WebsiteTexts.Queries.GetWebsiteTextByKey;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.WebsiteTexts.Queries.GetWebsiteTextByEncodedName
{
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
            var websiteText = await _websiteTextRepository.GetByKey(request.Key);
            var dto = _mapper.Map<WebsiteTextDto>(websiteText);
            return dto;
        }
    }
}
