using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.HomeBanners.Commands.EditHomeBanner
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
            var homeBanner = (await _homeBannerRepository.GetByEncodedNameAsync(request.EncodedName))!;
            homeBanner.ModifiedAt = DateTime.Now;

            var plTranslation = homeBanner.HomeBannerTranslations.First(hbt => hbt.Language.Code == "pl-PL");
            plTranslation.Text = request.TextPl;
            plTranslation.ModifiedAt = DateTime.Now;

            var enTranslation = homeBanner.HomeBannerTranslations.First(hbt => hbt.Language.Code == "en-GB");
            enTranslation.Text = request.TextEn;
            enTranslation.ModifiedAt = DateTime.Now;

            await _homeBannerRepository.CommitAsync();
            
            return Unit.Value;
        }
    }
}
