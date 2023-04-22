using MediatR;

namespace SmellIt.Application.SmellIt.WebsiteTexts.Commands.DeleteWebsiteTextByEncodedName
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
