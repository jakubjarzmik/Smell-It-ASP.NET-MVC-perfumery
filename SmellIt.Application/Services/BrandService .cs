using AutoMapper;
using SmellIt.Application.Dtos;
using SmellIt.Application.Extensions;
using SmellIt.Application.Services.Interfaces;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Services;
public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    private readonly ITranslationEngbService _translationEngbService;
    private readonly ITranslationPlplService _translationPlplService;

    public BrandService(IBrandRepository brandRepository, IMapper mapper, ITranslationEngbService translationEngbService, ITranslationPlplService translationPlplService)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        _translationEngbService = translationEngbService;
        _translationPlplService = translationPlplService;
    }
    public async Task Create(BrandDto brandDto)
    {
        var brand = _mapper.Map<Brand>(brandDto);
        await _brandRepository.Create(brand);

        await CreateTranslationsAsync(brandDto);
    }
    private async Task CreateTranslationsAsync(BrandDto brandDto)
    {
        var key = brandDto.NameEN.ConvertNameToKey();

        await CreateTranslationAsync(key, brandDto.NamePL, brandDto.NameEN);

        if (!(string.IsNullOrWhiteSpace(brandDto.DescriptionPL) || string.IsNullOrWhiteSpace(brandDto.DescriptionEN)))
        {
            await CreateTranslationAsync(key + "Desc", brandDto.DescriptionPL, brandDto.DescriptionEN);
        }
    }

    private async Task CreateTranslationAsync(string key, string valuePl, string valueEn)
    {
        var translationPlpl = new TranslationPlpl { Key = key, Value = valuePl };
        var translationEngb = new TranslationEngb { Key = key, Value = valueEn };

        await _translationPlplService.Create(translationPlpl);
        await _translationEngbService.Create(translationEngb);
    }

    public async Task<IEnumerable<BrandDto>> GetAll()
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