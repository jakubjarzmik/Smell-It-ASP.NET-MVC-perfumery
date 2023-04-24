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
            string fileName = file.FileName;
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "banners");
            string filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { FilePath = $"/images/banners/{fileName}" });
        }
    }
}
