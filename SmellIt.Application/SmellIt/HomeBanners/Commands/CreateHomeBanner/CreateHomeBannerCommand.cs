using MediatR;
using Microsoft.AspNetCore.Http;

namespace SmellIt.Application.SmellIt.HomeBanners.Commands.CreateHomeBanner
{
    public class CreateHomeBannerCommand : HomeBannerDto, IRequest
    {
        public IFormFile? ImageFile { get; set; }
    }
}
