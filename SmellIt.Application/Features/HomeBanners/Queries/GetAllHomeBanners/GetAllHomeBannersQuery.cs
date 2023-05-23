using MediatR;
using SmellIt.Application.Features.HomeBanners.DTOs;

namespace SmellIt.Application.Features.HomeBanners.Queries.GetAllHomeBanners
{
    public class GetAllHomeBannersQuery : IRequest<IEnumerable<HomeBannerDto>>
    {
    }
}
