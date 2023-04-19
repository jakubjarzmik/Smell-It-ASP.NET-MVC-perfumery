using MediatR;

namespace SmellIt.Application.SmellIt.FragranceCategories.Queries.GetFragranceCategoryByEncodedName
{
    public class GetFragranceCategoryByEncodedNameQuery : IRequest<FragranceCategoryDto>
    {
        public string EncodedName { get; set; }

        public GetFragranceCategoryByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
