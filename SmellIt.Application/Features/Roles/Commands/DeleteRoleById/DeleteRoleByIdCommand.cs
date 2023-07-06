using MediatR;

namespace SmellIt.Application.Features.Roles.Commands.DeleteRoleById;

public class DeleteRoleByIdCommand : IRequest
{
    public string Id { get; set; }

    public DeleteRoleByIdCommand(string id)
    {
        Id = id;
    }
}