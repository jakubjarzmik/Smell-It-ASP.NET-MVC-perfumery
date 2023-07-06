using MediatR;

namespace SmellIt.Application.Features.Users.Commands.ChangeUserRole;
public class ChangeUserRoleCommand : IRequest
{
    public string UserEmail { get; }
    public IEnumerable<string> Roles { get; }

    public ChangeUserRoleCommand(string userEmail, IEnumerable<string> roles)
    {
        UserEmail = userEmail;
        Roles = roles;
    }
}
