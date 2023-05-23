using MediatR;

namespace SmellIt.Application.Features.FragranceCategories.Commands.DeleteFragranceCategoryByEncodedName
{
    public class DeleteFragranceCategoryByEncodedNameCommand : IRequest
    {
        public string EncodedName { get; set; }

        public DeleteFragranceCategoryByEncodedNameCommand(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
