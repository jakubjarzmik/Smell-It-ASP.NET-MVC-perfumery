using MediatR;

namespace SmellIt.Application.Features.HomeBanners.Queries.GetAllHomeBanners
{
    public class GetAllHomeBannersQuery : IRequest<IEnumerable<HomeBannerDto>>
    {
    }
}
