using MediatR;

namespace SmellIt.Application.Features.Users.Commands.DeleteUserById;

public class DeleteUserByIdCommand : IRequest
{
    public string Id { get; set; }

    public DeleteUserByIdCommand(string id)
    {
        Id = id;
    }
}