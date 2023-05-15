using Dropbox.Api;
using Dropbox.Api.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace SmellIt.Application.Helpers.Images;

public class DropboxImageUploader : IImageUploader
{
    private readonly string _accessToken;

    public DropboxImageUploader(IOptions<DropboxSettings> settings)
    {
        _accessToken = settings.Value.AccessToken;
    }

    public async Task<string> UploadImageAsync(string path, IFormFile file, string key)
    {
        var extension = file.FileName[(file.FileName.LastIndexOf('.') + 1)..];

        using var dropboxClient = new DropboxClient(_accessToken);
        using var memoryStream = new MemoryStream();

        await file.CopyToAsync(memoryStream);

        memoryStream.Position = 0;

        var updated = await dropboxClient.Files.UploadAsync(
            $"/{path}/{key}.{extension}",
            WriteMode.Overwrite.Instance,
            body: memoryStream);

        var sharedUrl = await dropboxClient.Sharing.CreateSharedLinkWithSettingsAsync($"/{path}/{key}.{extension}");

        var modifiedUrl = sharedUrl.Url.Replace("?dl=0", "?raw=1");

        return modifiedUrl;
    }

}
