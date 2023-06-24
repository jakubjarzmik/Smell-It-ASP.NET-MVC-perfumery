using SmellIt.Application.Features.Users.DTOs;
using SmellIt.Application.ViewModels.Abstract;

namespace SmellIt.Application.ViewModels.Admin;

public class UsersViewModel : PaginatedViewModel<UserDto>
{
    public UsersViewModel(IEnumerable<UserDto> items, int totalItems, int currentPage, int pageSize) : base(items, totalItems, currentPage, pageSize)
    {
    }
}