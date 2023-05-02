using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.HomeBanners.Commands.EditHomeBanner
{
    public class EditHomeBannerCommandHandler : IRequestHandler<EditHomeBannerCommand>
    {
	    private readonly IHomeBannerRepository _homeBannerRepository;

	    public EditHomeBannerCommandHandler(IHomeBannerRepository homeBannerRepository)
	    {
		    _homeBannerRepository = homeBannerRepository;
	    }
        public async Task<Unit> Handle(EditHomeBannerCommand request, CancellationToken cancellationToken)
        {
            var homeBanner = (await _homeBannerRepository.GetByEncodedName(request.EncodedName))!;
            homeBanner.ModifiedAt = DateTime.UtcNow;

            var plTranslation = homeBanner.HomeBannerTranslations.First(hbt => hbt.Language.Code == "pl-PL");
            plTranslation.Text = request.TextPl;
            plTranslation.ModifiedAt = DateTime.UtcNow;

            var enTranslation = homeBanner.HomeBannerTranslations.First(hbt => hbt.Language.Code == "en-GB");
            enTranslation.Text = request.TextEn;
            enTranslation.ModifiedAt = DateTime.UtcNow;

            await _homeBannerRepository.Commit();
            
            return Unit.Value;
        }
    }
}
