using MediatR;

namespace SmellIt.Application.Features.SocialSites.Commands.DeleteSocialSiteByEncodedName;

public class DeleteSocialSiteByEncodedNameCommand : IRequest
{
    public string EncodedName { get; set; }

    public DeleteSocialSiteByEncodedNameCommand(string encodedName)
    {
        EncodedName = encodedName;
    }
}