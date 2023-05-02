using MediatR;

namespace SmellIt.Application.SmellIt.Languages.Queries.GetAllLanguages
{
    public class GetAllLanguagesQuery : IRequest<IEnumerable<LanguageDto>>
    {
    }
}
