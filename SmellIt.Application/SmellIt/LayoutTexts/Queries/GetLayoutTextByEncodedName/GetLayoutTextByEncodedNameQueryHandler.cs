using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.LayoutTexts.Queries.GetLayoutTextByEncodedName
{
    public class GetLayoutTextByEncodedNameQueryHandler : IRequestHandler<GetLayoutTextByEncodedNameQuery, LayoutTextDto>
    {
        private readonly ILayoutTextRepository _layoutTextRepository;
        private readonly IMapper _mapper;

        public GetLayoutTextByEncodedNameQueryHandler(ILayoutTextRepository layoutTextRepository, IMapper mapper)
        {
            _layoutTextRepository = layoutTextRepository;
            _mapper = mapper;
        }
        public async Task<LayoutTextDto> Handle(GetLayoutTextByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var layoutText = await _layoutTextRepository.GetByEncodedName(request.EncodedName);
            var dto = _mapper.Map<LayoutTextDto>(layoutText);
            return dto;
        }
    }
}
