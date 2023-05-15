using Microsoft.AspNetCore.Http;

namespace SmellIt.Application.Helpers.Images;
public interface IImageUploader : IHelper
{
    Task<string> UploadImageAsync(string path, IFormFile file, string key);
}