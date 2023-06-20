using MediatR;

namespace SmellIt.Application.Features.CartItems.Commands.AddCartItemToUser;

public class AddCartItemsToUserCommand : IRequest
{
    public string Email { get; set; }
    public string Session { get; set; }


    public AddCartItemsToUserCommand(string session, string email)
    {
        Email = email;
        Session = session;
    }
}