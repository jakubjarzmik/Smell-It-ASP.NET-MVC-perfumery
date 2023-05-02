using SmellIt.Application.SmellIt.HomeBanners;

namespace SmellIt.Admin.Helpers
{
    public static class BannerImageManager
    {
        public static async Task AddBannerImageAsync(IFormFile file, string fileName)
        {
            var extension = "." + file.FileName[(file.FileName.LastIndexOf('.') + 1)..];
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "banners");
            var filePath = Path.Combine(folderPath, fileName+extension);

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
