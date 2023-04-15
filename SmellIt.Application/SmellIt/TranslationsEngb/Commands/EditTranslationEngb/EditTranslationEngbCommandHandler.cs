using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.TranslationsEngb.Commands.EditTranslationEngb
{
    public class EditTranslationEngbCommandHandler : IRequestHandler<EditTranslationEngbCommand>
    {
        private readonly ITranslationEngbRepository _translationEngbRepository;

        public EditTranslationEngbCommandHandler(ITranslationEngbRepository translationEngbRepository)
        {
            _translationEngbRepository = translationEngbRepository;
        }
        public async Task<Unit> Handle(EditTranslationEngbCommand request, CancellationToken cancellationToken)
        {
            TranslationEngb translationEngb = (await _translationEngbRepository.GetByKey(request.Key))!;

            translationEngb.Value = request.Value;

            await _translationEngbRepository.Commit();
            return Unit.Value;
        }
    }
}
