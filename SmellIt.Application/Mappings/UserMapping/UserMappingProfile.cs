using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SmellIt.Application.Features.Users.DTOs;

namespace SmellIt.Application.Mappings.UserMapping;
public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<IdentityUser, UserDto>();
    }
}