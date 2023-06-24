using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Users.Commands.DeleteUserById;

public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserByIdCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.DeleteAsync(request.Id);

        return Unit.Value;
    }
}