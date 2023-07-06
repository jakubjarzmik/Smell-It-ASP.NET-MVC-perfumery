using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Roles.Commands.DeleteRoleById;

public class DeleteRoleByIdCommandHandler : IRequestHandler<DeleteRoleByIdCommand>
{
    private readonly IUserContext _userContext;
    private readonly IRoleRepository _roleRepository;

    public DeleteRoleByIdCommandHandler(IUserContext userContext,IRoleRepository roleRepository)
    {
        _userContext = userContext;
        _roleRepository = roleRepository;
    }

    public async Task<Unit> Handle(DeleteRoleByIdCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        await _roleRepository.DeleteAsync(request.Id);

        return Unit.Value;
    }
}