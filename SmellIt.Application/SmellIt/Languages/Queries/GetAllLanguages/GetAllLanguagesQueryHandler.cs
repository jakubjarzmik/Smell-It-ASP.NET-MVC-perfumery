using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Languages.Queries.GetAllLanguages;
public class GetAllLanguagesQueryHandler : IRequestHandler<GetAllLanguagesQuery, IEnumerable<LanguageDto>>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;

    public GetAllLanguagesQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<LanguageDto>> Handle(GetAllLanguagesQuery request, CancellationToken cancellationToken)
    {
        var languages = await _languageRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<LanguageDto>>(languages);
        return dtos;
    }
}
