using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Genders.Queries.GetAllGenders;
public class GetAllGendersQueryHandler : IRequestHandler<GetAllGendersQuery, IEnumerable<GenderDto>>
{
    private readonly IGenderRepository _genderRepository;
    private readonly IMapper _mapper;

    public GetAllGendersQueryHandler(IGenderRepository genderRepository, IMapper mapper)
    {
        _genderRepository = genderRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GenderDto>> Handle(GetAllGendersQuery request, CancellationToken cancellationToken)
    {
        var genders = await _genderRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<GenderDto>>(genders);
        return dtos;
    }
}
