using MediatR;

namespace SmellIt.Application.Features.Products.Commands.DeleteProductByEncodedName
{
    public class DeleteProductByEncodedNameCommand : IRequest
    {
        public string EncodedName { get; set; }

        public DeleteProductByEncodedNameCommand(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
