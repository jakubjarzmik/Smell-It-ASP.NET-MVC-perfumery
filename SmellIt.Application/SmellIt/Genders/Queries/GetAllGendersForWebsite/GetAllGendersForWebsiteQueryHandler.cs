using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Genders.Queries.GetAllGendersForWebsite;
public class GetAllGendersForWebsiteQueryHandler : IRequestHandler<GetAllGendersForWebsiteQuery, IEnumerable<WebsiteGenderDto>>
{
    private readonly IGenderRepository _genderRepository;
    private readonly IMapper _mapper;

    public GetAllGendersForWebsiteQueryHandler(IGenderRepository genderRepository, IMapper mapper)
    {
        _genderRepository = genderRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<WebsiteGenderDto>> Handle(GetAllGendersForWebsiteQuery request, CancellationToken cancellationToken)
    {
        var genders = await _genderRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<WebsiteGenderDto>>(genders, opt =>
        {
            opt.Items["LanguageCode"] = request.LanguageCode;
        });
        return dtos;
    }
}
