using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.WebsiteTexts.Commands.CreateWebsiteText
{
    public class CreateWebsiteTextCommandHandler : IRequestHandler<CreateWebsiteTextCommand>
    {
        private readonly IWebsiteTextRepository _websiteTextRepository;
        private readonly IMapper _mapper;
        public CreateWebsiteTextCommandHandler(IWebsiteTextRepository websiteTextRepository, IMapper mapper)
        {
            _websiteTextRepository = websiteTextRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateWebsiteTextCommand request, CancellationToken cancellationToken)
        {
            var websiteText = _mapper.Map<WebsiteText>(request);

            await _websiteTextRepository.Create(websiteText);

            return Unit.Value;
        }
    }
}
