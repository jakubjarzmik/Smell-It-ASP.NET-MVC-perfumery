using MediatR;

namespace SmellIt.Application.SmellIt.HomeBanners.Queries.GetAllHomeBanners
{
    public class GetAllHomeBannersQuery : IRequest<IEnumerable<HomeBannerDto>>
    {
    }
}
