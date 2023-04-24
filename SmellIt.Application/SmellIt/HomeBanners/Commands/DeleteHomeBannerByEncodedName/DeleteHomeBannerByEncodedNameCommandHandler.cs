﻿using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.HomeBanners.Commands.DeleteHomeBannerByEncodedName
{
    public class DeleteHomeBannerByEncodedNameCommandHandler : IRequestHandler<DeleteHomeBannerByEncodedNameCommand>
    {
	    private readonly IHomeBannerRepository _homeBannerRepository;
	    private readonly IHomeBannerTranslationRepository _homeBannerTranslationRepository;

	    public DeleteHomeBannerByEncodedNameCommandHandler(IHomeBannerRepository homeBannerRepository, IHomeBannerTranslationRepository homeBannerTranslationRepository)
	    {
		    _homeBannerRepository = homeBannerRepository;
		    _homeBannerTranslationRepository = homeBannerTranslationRepository;
	    }

        public async Task<Unit> Handle(DeleteHomeBannerByEncodedNameCommand request, CancellationToken cancellationToken)
        {
            var homeBanner = (await _homeBannerRepository.GetByEncodedName(request.EncodedName))!;
            homeBanner.IsActive = false;
            homeBanner.DeletedAt = DateTime.UtcNow;

            var homeBannerTranslations = await _homeBannerTranslationRepository.GetHomeBannerTranslations(homeBanner.Id);
            foreach (var homeBannerTranslation in homeBannerTranslations)
            {
                homeBannerTranslation.IsActive = false;
                homeBannerTranslation.DeletedAt = DateTime.UtcNow;
            }

            await _homeBannerRepository.Commit();
            return Unit.Value;
        }
    }
}
