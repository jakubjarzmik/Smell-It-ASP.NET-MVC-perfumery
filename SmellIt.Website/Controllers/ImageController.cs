using Microsoft.AspNetCore.Mvc;

namespace SmellIt.Website.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var fileName = file.FileName;
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "banners");
            var filePath = Path.Combine(folderPath, fileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { FilePath = $"/images/banners/{fileName}" });
        }
    }
}
