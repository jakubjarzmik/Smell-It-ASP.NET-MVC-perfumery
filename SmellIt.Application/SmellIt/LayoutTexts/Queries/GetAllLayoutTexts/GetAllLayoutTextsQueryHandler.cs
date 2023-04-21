using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.LayoutTexts.Queries.GetAllLayoutTexts;
public class GetAllLayoutTextsQueryHandler : IRequestHandler<GetAllLayoutTextsQuery, IEnumerable<LayoutTextDto>>
{
    private readonly ILayoutTextRepository _layoutTextRepository;
    private readonly IMapper _mapper;

    public GetAllLayoutTextsQueryHandler(ILayoutTextRepository layoutTextRepository, IMapper mapper)
    {
        _layoutTextRepository = layoutTextRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<LayoutTextDto>> Handle(GetAllLayoutTextsQuery request, CancellationToken cancellationToken)
    {
        var layoutTexts = await _layoutTextRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<LayoutTextDto>>(layoutTexts);
        return dtos;
    }
}
