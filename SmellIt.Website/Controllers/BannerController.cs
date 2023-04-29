using Microsoft.AspNetCore.Mvc;
using SmellIt.Website.Helpers;

namespace SmellIt.Website.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BannerController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            await BannerImageManager.AddBannerImageAsync(file);

            return Ok(new { FilePath = $"/images/banners/{file.FileName}" });
        }
    }
}
