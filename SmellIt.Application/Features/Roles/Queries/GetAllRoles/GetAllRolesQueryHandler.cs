using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Roles.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Roles.Queries.GetAllRoles;
public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<RoleDto>>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public GetAllRolesQueryHandler(IRoleRepository roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await _roleRepository.GetAllAsync();
        var roleDtos = _mapper.Map<IEnumerable<RoleDto>>(roles);

        return roleDtos;
    }
}
