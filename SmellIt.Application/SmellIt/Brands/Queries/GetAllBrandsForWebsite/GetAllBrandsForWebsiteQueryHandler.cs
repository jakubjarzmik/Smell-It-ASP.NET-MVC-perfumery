using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Brands.Queries.GetAllBrandsForWebsite;
public class GetAllBrandsForWebsiteQueryHandler : IRequestHandler<GetAllBrandsForWebsiteQuery, IEnumerable<WebsiteBrandDto>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetAllBrandsForWebsiteQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<WebsiteBrandDto>> Handle(GetAllBrandsForWebsiteQuery request, CancellationToken cancellationToken)
    {
        var brands = await _brandRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<WebsiteBrandDto>>(brands, opt =>
        {
            opt.Items["LanguageCode"] = request.LanguageCode;
        });
        return dtos;
    }
}
