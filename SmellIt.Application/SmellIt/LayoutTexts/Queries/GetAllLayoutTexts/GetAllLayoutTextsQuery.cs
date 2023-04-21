using MediatR;

namespace SmellIt.Application.SmellIt.LayoutTexts.Queries.GetAllLayoutTexts
{
    public class GetAllLayoutTextsQuery : IRequest<IEnumerable<LayoutTextDto>>
    {
    }
}
