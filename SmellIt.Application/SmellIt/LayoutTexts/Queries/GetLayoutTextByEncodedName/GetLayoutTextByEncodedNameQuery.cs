using MediatR;

namespace SmellIt.Application.SmellIt.LayoutTexts.Queries.GetLayoutTextByEncodedName
{
    public class GetLayoutTextByEncodedNameQuery : IRequest<LayoutTextDto>
    {
        public string EncodedName { get; set; }

        public GetLayoutTextByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
