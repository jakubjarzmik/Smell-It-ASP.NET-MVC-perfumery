using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.TranslationsPlpl.Commands.EditTranslationPlpl
{
    public class EditTranslationPlplCommandHandler : IRequestHandler<EditTranslationPlplCommand>
    {
        private readonly ITranslationPlplRepository _translationPlplRepository;

        public EditTranslationPlplCommandHandler(ITranslationPlplRepository translationPlplRepository)
        {
            _translationPlplRepository = translationPlplRepository;
        }
        public async Task<Unit> Handle(EditTranslationPlplCommand request, CancellationToken cancellationToken)
        {
            TranslationPlpl translationPlpl = (await _translationPlplRepository.GetByKey(request.Key))!;

            translationPlpl.Value = request.Value;

            await _translationPlplRepository.Commit();
            return Unit.Value;
        }
    }
}
