using MediatR;

namespace SmellIt.Application.Features.Brands.Commands.DeleteBrandByEncodedName
{
    public class DeleteBrandByEncodedNameCommand : IRequest
    {
        public string EncodedName { get; set; }

        public DeleteBrandByEncodedNameCommand(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
