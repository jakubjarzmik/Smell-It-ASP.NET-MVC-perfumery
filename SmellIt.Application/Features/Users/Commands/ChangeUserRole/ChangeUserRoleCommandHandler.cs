using MediatR;
using Microsoft.AspNetCore.Identity;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Users.Commands.ChangeUserRole;
public class ChangeUserRoleCommandHandler : IRequestHandler<ChangeUserRoleCommand>
{
    private readonly IUserContext _userContext;
    private readonly IUserRepository _userRepository;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ChangeUserRoleCommandHandler(IUserContext userContext, IUserRepository userRepository, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userContext = userContext;
        _userRepository = userRepository;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task<Unit> Handle(ChangeUserRoleCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin") || request.UserEmail == "admin@smellit.com")
        {
            return Unit.Value;
        }

        var user = await _userRepository.GetByEmailAsync(request.UserEmail);
        var currentRoles = await _userManager.GetRolesAsync(user!);

        var rolesToAdd = request.Roles.Except(currentRoles).ToList();
        var rolesToRemove = currentRoles.Except(request.Roles).ToList();

        if (rolesToRemove.Any())
        {
            await _userManager.RemoveFromRolesAsync(user!, rolesToRemove);
        }

        if (rolesToAdd.Any())
        {
            await _userManager.AddToRolesAsync(user!, rolesToAdd);
        }

        return Unit.Value;
    }
}