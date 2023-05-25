using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SmellIt.Application.Helpers.Images;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.HomeBanners.Commands.CreateHomeBanner
{
    public class CreateHomeBannerCommandHandler : IRequestHandler<CreateHomeBannerCommand>
    {
        private readonly IHomeBannerRepository _homeBannerRepository;
        private readonly IMapper _mapper;
        private readonly IImageUploader _imageUploader;
        public CreateHomeBannerCommandHandler(IHomeBannerRepository homeBannerRepository, IMapper mapper, IImageUploader imageUploader)
        {
            _homeBannerRepository = homeBannerRepository;
            _mapper = mapper;
            _imageUploader = imageUploader;
        }

        public async Task<Unit> Handle(CreateHomeBannerCommand request, CancellationToken cancellationToken)
        {
            var homeBanner = _mapper.Map<HomeBanner>(request);
            await HandleHomeBannerImage(request.ImageFile, homeBanner);
            await _homeBannerRepository.CreateAsync(homeBanner);
            return Unit.Value;
        }

        private async Task HandleHomeBannerImage(IFormFile? imageFile, HomeBanner homeBanner)
        {
            if (imageFile != null)
            {
                string imagePath = await _imageUploader.UploadImageAsync("HomeBanners", imageFile, homeBanner.Key);
                homeBanner.ImagePath = imagePath;
            }
        }
    }
}
