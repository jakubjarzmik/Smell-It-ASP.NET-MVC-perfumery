using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SmellIt.Application.Features.Roles.DTOs;
using SmellIt.Application.Features.Users.DTOs;
using SmellIt.Application.ViewModels.Admin;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Users.Queries.GetPaginatedUsers;
public class GetPaginatedUsersQueryHandler : IRequestHandler<GetPaginatedUsersQuery, UsersViewModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<IdentityUser> _userManager;

    public GetPaginatedUsersQueryHandler(IUserRepository userRepository, IMapper mapper, UserManager<IdentityUser> userManager)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task<UsersViewModel> Handle(GetPaginatedUsersQuery request, CancellationToken cancellationToken)
    {
        var totalUsers = await _userRepository.CountAsync();
        var users = await _userRepository.GetPaginatedAsync(request.PageNumber, request.PageSize);

        List<UserDto> userDtos = new();

        foreach (var user in users)
        {
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Roles = await _userManager.GetRolesAsync(user);
            userDtos.Add(userDto);
        }

        var viewModel = new UsersViewModel(userDtos, totalUsers, request.PageNumber, request.PageSize);

        return viewModel;
    }
}
