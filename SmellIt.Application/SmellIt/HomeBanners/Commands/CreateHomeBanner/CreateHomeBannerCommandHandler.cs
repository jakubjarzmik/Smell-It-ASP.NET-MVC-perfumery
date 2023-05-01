using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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

        private async Task<string> UploadImageAsync(IFormFile file, string key)
        {
            using var httpClient = new HttpClient();
            using var content = new MultipartFormDataContent();
            await using var fileStream = file.OpenReadStream();
            var extension = "." + file.FileName[(file.FileName.LastIndexOf('.') + 1)..];


            content.Add(new StreamContent(fileStream), "file", key + extension);
            var response = await httpClient.PostAsync("https://localhost:7282/Banner/upload", content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<UploadResponse>(responseContent);
                return jsonResponse!.FilePath!;
            }
            else
            {
                throw new Exception("Failed to upload the image");
            }
        }

        private class UploadResponse
        {
            public string FilePath { get; set; } = default!;
        }

        private async Task CompleteTranslationFields(CreateHomeBannerCommand request, HomeBanner homeBanner)
        {
            bool isPlTranslationAdded = false;
            foreach (var translation in homeBanner.HomeBannerTranslations!)
            {
                translation.HomeBanner = homeBanner;

                if (translation.Text == request.TextPL && !isPlTranslationAdded)
                {
                    translation.Language = (await _languageRepository.GetByCode("pl-PL"))!;
                    isPlTranslationAdded = true;
                }
                else if (translation.Text == request.TextEN)
                    translation.Language = (await _languageRepository.GetByCode("en-GB"))!;
                translation.EncodeName();
            }
        }

        public async Task<Unit> Handle(CreateHomeBannerCommand request, CancellationToken cancellationToken)
        {
            var homeBanner = _mapper.Map<HomeBanner>(request);
            homeBanner.EncodeName();
            try
            {
                if (request.ImageFile != null)
                {
                    string imagePath = await UploadImageAsync(request.ImageFile, homeBanner.Key);
                    homeBanner.ImagePath = imagePath;
                }

                await CompleteTranslationFields(request, homeBanner);

                await _homeBannerRepository.Create(homeBanner);
            }
            catch (Exception ex)
            {
                
            }

            return Unit.Value;
        }
    }
}
