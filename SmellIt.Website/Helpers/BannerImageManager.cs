using SmellIt.Application.SmellIt.HomeBanners;
using SmellIt.Application.SmellIt.HomeBanners.Queries.GetAllHomeBanners;

namespace SmellIt.Website.Helpers
{
    public static class BannerImageManager
    {
        public static async Task AddBannerImageAsync(IFormFile file)
        {
            var fileName = file.FileName;
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "banners");
            var filePath = Path.Combine(folderPath, fileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
        }
        public static void DeleteNonExistentBanners(IEnumerable<HomeBannerDto>? banners, IWebHostEnvironment env)
        {
            if (banners == null)
                return;

            var bannerKeys = banners.Select(b => b.Key);

            var imagesFolderPath = Path.Combine(env.WebRootPath, "images/banners");

            var filesInFolder = Directory.GetFiles(imagesFolderPath);

            foreach (var filePath in filesInFolder)
            {
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                if (!bannerKeys.Contains(fileName))
                {
                    System.IO.File.Delete(filePath);
                }
            }
        }
    }
}
