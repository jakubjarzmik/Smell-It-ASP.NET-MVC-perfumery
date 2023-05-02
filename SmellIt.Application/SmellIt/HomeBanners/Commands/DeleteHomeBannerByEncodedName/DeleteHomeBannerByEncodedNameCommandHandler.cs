using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.HomeBanners.Commands.DeleteHomeBannerByEncodedName
{
    public class DeleteHomeBannerByEncodedNameCommandHandler : IRequestHandler<DeleteHomeBannerByEncodedNameCommand>
    {
	    private readonly IHomeBannerRepository _homeBannerRepository;

	    public DeleteHomeBannerByEncodedNameCommandHandler(IHomeBannerRepository homeBannerRepository)
	    {
		    _homeBannerRepository = homeBannerRepository;
	    }

        public async Task<Unit> Handle(DeleteHomeBannerByEncodedNameCommand request, CancellationToken cancellationToken)
        {
            var homeBanner = (await _homeBannerRepository.GetByEncodedName(request.EncodedName))!;
            homeBanner.IsActive = false;
            homeBanner.DeletedAt = DateTime.UtcNow;

            foreach (var homeBannerTranslation in homeBanner.HomeBannerTranslations)
            {
                homeBannerTranslation.IsActive = false;
                homeBannerTranslation.DeletedAt = DateTime.UtcNow;
            }

            await _homeBannerRepository.Commit();
            return Unit.Value;
        }
    }
}
