using AutoMapper;
using MediatR;
using SmellIt.Application.Helpers;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.HomeBanners.Commands.CreateHomeBanner
{
    public class CreateHomeBannerCommandHandler : IRequestHandler<CreateHomeBannerCommand>
    {
	    private readonly IHomeBannerRepository _homeBannerRepository;
        private readonly IMapper _mapper;
        private readonly string _bannerUploadUrl = "https://localhost:7282/Banner/upload";
        public CreateHomeBannerCommandHandler(IHomeBannerRepository homeBannerRepository, IMapper mapper)
        {
            _homeBannerRepository = homeBannerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateHomeBannerCommand request, CancellationToken cancellationToken)
        {
            var homeBanner = _mapper.Map<HomeBanner>(request);
            try
            {
                if (request.ImageFile != null)
                {
                    string imagePath = await ImageUploader.UploadImageAsync(_bannerUploadUrl, request.ImageFile, homeBanner.Key);
                    homeBanner.ImagePath = imagePath;
                }
                await _homeBannerRepository.Create(homeBanner);
            }
            catch (Exception)
            {
                
            }

            return Unit.Value;
        }
    }
}
