using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.WebsiteTexts.Commands.DeleteWebsiteTextByEncodedName;

public class DeleteWebsiteTextByEncodedNameCommandHandler : IRequestHandler<DeleteWebsiteTextByEncodedNameCommand>
{
    private readonly IUserContext _userContext;
    private readonly IWebsiteTextRepository _websiteTextRepository;

    public DeleteWebsiteTextByEncodedNameCommandHandler(IUserContext userContext,IWebsiteTextRepository websiteTextRepository)
    {
        _userContext = userContext;
        _websiteTextRepository = websiteTextRepository;
    }

    public async Task<Unit> Handle(DeleteWebsiteTextByEncodedNameCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        await _websiteTextRepository.DeleteAsync(request.EncodedName);
        return Unit.Value;
    }
}