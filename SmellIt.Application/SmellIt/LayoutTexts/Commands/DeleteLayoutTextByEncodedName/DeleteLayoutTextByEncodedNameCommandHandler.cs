using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.LayoutTexts.Commands.DeleteLayoutTextByEncodedName
{
    public class DeleteLayoutTextByEncodedNameCommandHandler : IRequestHandler<DeleteLayoutTextByEncodedNameCommand>
    {
        private readonly ILayoutTextRepository _layoutTextRepository;
        private readonly ILayoutTextTranslationRepository _layoutTextTranslationRepository;

        public DeleteLayoutTextByEncodedNameCommandHandler(ILayoutTextRepository layoutTextRepository, ILayoutTextTranslationRepository layoutTextTranslationRepository)
        {
            _layoutTextRepository = layoutTextRepository;
            _layoutTextTranslationRepository = layoutTextTranslationRepository;
        }

        public async Task<Unit> Handle(DeleteLayoutTextByEncodedNameCommand request, CancellationToken cancellationToken)
        {
            var layoutText = (await _layoutTextRepository.GetByEncodedName(request.EncodedName))!;
            layoutText.IsActive = false;
            layoutText.DeletedAt = DateTime.UtcNow;

            var layoutTextTranslations = await _layoutTextTranslationRepository.GetLayoutTextTranslations(layoutText.Id);
            foreach (var brandTranslation in layoutTextTranslations)
            {
                brandTranslation.IsActive = false;
                brandTranslation.DeletedAt = DateTime.UtcNow;
            }

            await _layoutTextRepository.Commit();
            return Unit.Value;
        }
    }
}
