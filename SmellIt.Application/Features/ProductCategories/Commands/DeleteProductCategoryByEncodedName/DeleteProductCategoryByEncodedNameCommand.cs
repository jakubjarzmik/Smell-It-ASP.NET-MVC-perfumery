using MediatR;

namespace SmellIt.Application.Features.ProductCategories.Commands.DeleteProductCategoryByEncodedName;

public class DeleteProductCategoryByEncodedNameCommand : IRequest
{
    public string EncodedName { get; set; }

    public DeleteProductCategoryByEncodedNameCommand(string encodedName)
    {
        EncodedName = encodedName;
    }
}