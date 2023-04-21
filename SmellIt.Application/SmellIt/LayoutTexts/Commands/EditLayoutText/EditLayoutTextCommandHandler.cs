using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.LayoutTexts.Commands.EditLayoutText
{
    public class EditLayoutTextCommandHandler : IRequestHandler<EditLayoutTextCommand>
    {
        private readonly ILayoutTextRepository _layoutTextRepository;
        private readonly ILayoutTextTranslationRepository _layoutTextTranslationRepository;

        public EditLayoutTextCommandHandler(ILayoutTextRepository layoutTextRepository, ILayoutTextTranslationRepository layoutTextTranslationRepository)
        {
            _layoutTextRepository = layoutTextRepository;
            _layoutTextTranslationRepository = layoutTextTranslationRepository;
        }
        public async Task<Unit> Handle(EditLayoutTextCommand request, CancellationToken cancellationToken)
        {
            var layoutText = (await _layoutTextRepository.GetByEncodedName(request.EncodedName))!;
            layoutText.ModifiedAt = DateTime.UtcNow;

            var plTranslation = (await _layoutTextTranslationRepository.GetTranslation(layoutText.Id, "pl-PL"))!;
            plTranslation.Text = request.TextPL;
            plTranslation.ModifiedAt = DateTime.UtcNow;

            var enTranslation = (await _layoutTextTranslationRepository.GetTranslation(layoutText.Id, "en-GB"))!;
            enTranslation.Text = request.TextEN;
            enTranslation.ModifiedAt = DateTime.UtcNow;

            await _layoutTextRepository.Commit();
            
            return Unit.Value;
        }
    }
}
