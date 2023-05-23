using MediatR;
using SmellIt.Application.Features.Languages.DTOs;

namespace SmellIt.Application.Features.Languages.Queries.GetAllLanguages
{
    public class GetAllLanguagesQuery : IRequest<IEnumerable<LanguageDto>>
    {
    }
}
