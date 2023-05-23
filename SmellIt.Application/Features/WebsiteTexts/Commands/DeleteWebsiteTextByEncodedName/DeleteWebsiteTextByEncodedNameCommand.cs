using MediatR;

namespace SmellIt.Application.Features.WebsiteTexts.Commands.DeleteWebsiteTextByEncodedName
{
    public class DeleteWebsiteTextByEncodedNameCommand : IRequest
    {
        public string EncodedName { get; set; }

        public DeleteWebsiteTextByEncodedNameCommand(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
