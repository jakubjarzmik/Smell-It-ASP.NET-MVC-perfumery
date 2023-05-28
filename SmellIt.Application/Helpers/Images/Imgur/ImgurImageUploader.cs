using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace SmellIt.Application.Helpers.Images.Imgur;

public class ImgurImageUploader : IImageUploader
{
    private readonly string _clientId;
    private readonly string _clientSecret;

    public ImgurImageUploader(IOptions<ImgurSettings> settings)
    {
        _clientId = settings.Value.ClientId;
        _clientSecret = settings.Value.ClientSecret;
    }

    public async Task<string> UploadImageAsync(string path, IFormFile file, string key)
    {
        var client = new ImgurClient(_clientId, _clientSecret);
        var endpoint = new ImageEndpoint(client);

        byte[] fileBytes;

        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            fileBytes = memoryStream.ToArray();
        }

        try
        {
            IImage image = await endpoint.UploadImageBinaryAsync(fileBytes);
            return image.Link;
        }
        catch (Exception ex)
        {
            throw new Exception($"There was a problem uploading the image to Imgur: {ex.Message}", ex);
        }
    }
}