using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.LayoutTexts.Commands.CreateLayoutText
{
    public class CreateLayoutTextCommandHandler : IRequestHandler<CreateLayoutTextCommand>
    {
        private readonly ILayoutTextRepository _layoutTextRepository;
        private readonly IMapper _mapper;
        public CreateLayoutTextCommandHandler(ILayoutTextRepository layoutTextRepository, IMapper mapper)
        {
            _layoutTextRepository = layoutTextRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateLayoutTextCommand request, CancellationToken cancellationToken)
        {
            var layoutText = _mapper.Map<LayoutText>(request);
            layoutText.EncodeName();

            foreach (var translation in layoutText.LayoutTextTranslations!)
            {
                translation.LayoutText = layoutText;
                translation.EncodeName();
            }

            await _layoutTextRepository.Create(layoutText);

            return Unit.Value;
        }
    }
}
