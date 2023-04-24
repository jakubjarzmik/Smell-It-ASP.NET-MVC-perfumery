using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.HomeBanners.Commands.EditHomeBanner
{
    public class EditHomeBannerCommandHandler : IRequestHandler<EditHomeBannerCommand>
    {
	    private readonly IHomeBannerRepository _homeBannerRepository;
	    private readonly IHomeBannerTranslationRepository _homeBannerTranslationRepository;

	    public EditHomeBannerCommandHandler(IHomeBannerRepository homeBannerRepository, IHomeBannerTranslationRepository homeBannerTranslationRepository)
	    {
		    _homeBannerRepository = homeBannerRepository;
		    _homeBannerTranslationRepository = homeBannerTranslationRepository;
	    }
        public async Task<Unit> Handle(EditHomeBannerCommand request, CancellationToken cancellationToken)
        {
            var homeBanner = (await _homeBannerRepository.GetByEncodedName(request.EncodedName))!;
            homeBanner.ImagePath = request.ImagePath;
            homeBanner.ImageAlt = request.ImageAlt;
            homeBanner.ModifiedAt = DateTime.UtcNow;

            var plTranslation = (await _homeBannerTranslationRepository.GetTranslation(homeBanner.Id, "pl-PL"))!;
            plTranslation.Text = request.TextPL;
            plTranslation.ModifiedAt = DateTime.UtcNow;

            var enTranslation = (await _homeBannerTranslationRepository.GetTranslation(homeBanner.Id, "en-GB"))!;
            enTranslation.Text = request.TextEN;
            enTranslation.ModifiedAt = DateTime.UtcNow;

            await _homeBannerRepository.Commit();
            
            return Unit.Value;
        }
    }
}
