using AutoMapper;
using MediatR;
using SmellIt.Application.Services.Interfaces;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Brands.Queries.GetAllBrands;
public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, IEnumerable<BrandDto>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly ITranslationEngbService _translationEngbService;
    private readonly ITranslationPlplService _translationPlplService;

    public GetAllBrandsQueryHandler(IBrandRepository brandRepository, ITranslationEngbService translationEngbService, ITranslationPlplService translationPlplService)
    {
        _brandRepository = brandRepository;
        _translationEngbService = translationEngbService;
        _translationPlplService = translationPlplService;
    }
    public async Task<IEnumerable<BrandDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await _brandRepository.GetAll();

        var dtos = new List<BrandDto>();

        foreach (var brand in brands)
        {
            var dto = await ConvertToBrandDto(brand);
            dtos.Add(dto);
        }

        return dtos;
    }

    private async Task<BrandDto> ConvertToBrandDto(Brand brand)
    {
        var nameEn = await _translationEngbService.GetByKey(brand.NameKey);
        var namePl = await _translationPlplService.GetByKey(brand.NameKey);

        var descriptionEn = brand.DescriptionKey != null ? await _translationEngbService.GetByKey(brand.DescriptionKey) : null;
        var descriptionPl = brand.DescriptionKey != null ? await _translationPlplService.GetByKey(brand.DescriptionKey) : null;

        return new BrandDto
        {
            NameEN = nameEn?.Value ?? string.Empty,
            NamePL = namePl?.Value ?? string.Empty,
            DescriptionEN = descriptionEn?.Value,
            DescriptionPL = descriptionPl?.Value
        };
    }
}
