using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Users.Commands.DeleteUserById;

public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand>
{
    private readonly IUserContext _userContext;
    private readonly IUserRepository _userRepository;

    public DeleteUserByIdCommandHandler(IUserContext userContext,IUserRepository userRepository)
    {
        _userContext = userContext;
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        await _userRepository.DeleteAsync(request.Id);

        return Unit.Value;
    }
}