using MediatR;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.SmellIt.Languages.Queries.GetAllLanguages
{
    public class GetAllLanguagesQuery : IRequest<IEnumerable<LanguageDto>>
    {
    }
}
