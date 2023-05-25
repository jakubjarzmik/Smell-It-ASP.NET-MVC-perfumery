using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Genders.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Genders.Queries.GetAllGenders;
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
        var genders = await _genderRepository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<GenderDto>>(genders);
        return dtos;
    }
}
