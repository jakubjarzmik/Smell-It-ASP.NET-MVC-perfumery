using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.HomeBanners.Commands.CreateHomeBanner
{
    public class CreateHomeBannerCommandHandler : IRequestHandler<CreateHomeBannerCommand>
    {
	    private readonly IHomeBannerRepository _homeBannerRepository;
	    private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        public CreateHomeBannerCommandHandler(IHomeBannerRepository homeBannerRepository,ILanguageRepository languageRepository, IMapper mapper)
        {
            _homeBannerRepository = homeBannerRepository;
            _languageRepository = languageRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateHomeBannerCommand request, CancellationToken cancellationToken)
        {
            var homeBanner = _mapper.Map<HomeBanner>(request);
            homeBanner.EncodeName();

            foreach (var translation in homeBanner.HomeBannerTranslations!)
            {
                translation.HomeBanner = homeBanner;
                if (translation.Text == request.TextPL)
                    translation.Language = (await _languageRepository.GetByCode("pl-PL"))!;
                else if (translation.Text == request.TextEN)
                    translation.Language = (await _languageRepository.GetByCode("en-GB"))!;
                translation.EncodeName();
            }

            await _homeBannerRepository.Create(homeBanner);

            return Unit.Value;
        }
    }
}
