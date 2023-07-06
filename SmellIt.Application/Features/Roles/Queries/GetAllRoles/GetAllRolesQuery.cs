using MediatR;
using SmellIt.Application.Features.Roles.DTOs;

namespace SmellIt.Application.Features.Roles.Queries.GetAllRoles;

public class GetAllRolesQuery : IRequest<IEnumerable<RoleDto>>
{
    public GetAllRolesQuery()
    {
    }
}