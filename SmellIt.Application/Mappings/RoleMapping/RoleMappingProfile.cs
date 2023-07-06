using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SmellIt.Application.Features.Roles.DTOs;

namespace SmellIt.Application.Mappings.RoleMapping;
public class RoleMappingProfile : Profile
{
    public RoleMappingProfile()
    {
        CreateMap<IdentityRole, RoleDto>();
    }
}