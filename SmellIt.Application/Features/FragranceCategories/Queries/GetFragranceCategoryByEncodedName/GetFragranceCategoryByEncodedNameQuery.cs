using MediatR;
using SmellIt.Application.Features.FragranceCategories.DTOs;

namespace SmellIt.Application.Features.FragranceCategories.Queries.GetFragranceCategoryByEncodedName
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
