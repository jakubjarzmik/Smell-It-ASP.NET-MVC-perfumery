using MediatR;

namespace SmellIt.Application.Features.Languages.Queries.GetAllLanguages
{
    public class GetAllLanguagesQuery : IRequest<IEnumerable<LanguageDto>>
    {
    }
}
