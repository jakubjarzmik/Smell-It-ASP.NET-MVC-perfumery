using MediatR;
using Microsoft.AspNetCore.Http;

namespace SmellIt.Application.Features.HomeBanners.Commands.CreateHomeBanner
{
    public class CreateHomeBannerCommand : HomeBannerDto, IRequest
    {
        public IFormFile? ImageFile { get; set; }
    }
}
