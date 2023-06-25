using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SmellIt.Application.Features.Orders.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.OrderMapping;
public class UserResolver : IValueResolver<OrderCreateDto, Order, IdentityUser>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserContext _userContext;

    public UserResolver(IUserRepository userRepository, IUserContext userContext)
    {
        _userRepository = userRepository;
        _userContext = userContext;
    }

    public IdentityUser Resolve(OrderCreateDto source, Order destination, IdentityUser destMember, ResolutionContext context)
    {
        return _userRepository.GetByEmail(_userContext.GetCurrentUser()!.Email)!;
    }
}