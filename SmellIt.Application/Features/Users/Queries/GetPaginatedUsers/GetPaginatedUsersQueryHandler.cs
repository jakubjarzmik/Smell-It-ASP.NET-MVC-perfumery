using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Users.DTOs;
using SmellIt.Application.ViewModels.Admin;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Users.Queries.GetPaginatedUsers;
public class GetPaginatedUsersQueryHandler : IRequestHandler<GetPaginatedUsersQuery, UsersViewModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetPaginatedUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<UsersViewModel> Handle(GetPaginatedUsersQuery request, CancellationToken cancellationToken)
    {
        var totalUsers = await _userRepository.CountAsync();
        var users = await _userRepository.GetPaginatedAsync(request.PageNumber, request.PageSize);

        var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

        var viewModel = new UsersViewModel(userDtos, totalUsers, request.PageNumber, request.PageSize);

        return viewModel;
    }
}
