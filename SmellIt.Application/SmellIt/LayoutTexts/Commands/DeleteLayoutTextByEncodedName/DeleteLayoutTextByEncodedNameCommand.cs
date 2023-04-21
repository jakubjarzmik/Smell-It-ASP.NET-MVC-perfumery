using MediatR;

namespace SmellIt.Application.SmellIt.LayoutTexts.Commands.DeleteLayoutTextByEncodedName
{
    public class DeleteLayoutTextByEncodedNameCommand : IRequest
    {
        public string EncodedName { get; set; }

        public DeleteLayoutTextByEncodedNameCommand(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
