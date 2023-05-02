using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SmellIt.Application.Helpers;
public static class ImageUploader
{
    public static async Task<string> UploadImageAsync(string url, IFormFile file, string key)
    {
        using var httpClient = new HttpClient();
        using var content = new MultipartFormDataContent();
        await using var fileStream = file.OpenReadStream();
        var extension = "." + file.FileName[(file.FileName.LastIndexOf('.') + 1)..];

        content.Add(new StreamContent(fileStream), "file", key + extension);
        var response = await httpClient.PostAsync(url, content);
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
}
