using MediatR;

namespace SmellIt.Application.SmellIt.ProductCategories.Commands.DeleteProductCategoryByEncodedName
{
    public class DeleteProductCategoryByEncodedNameCommand : IRequest
    {
        public string EncodedName { get; set; }

        public DeleteProductCategoryByEncodedNameCommand(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
