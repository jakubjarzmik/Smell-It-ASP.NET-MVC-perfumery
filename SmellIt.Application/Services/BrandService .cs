using AutoMapper;
using SmellIt.Application.Dtos;
using SmellIt.Application.Services.Interfaces;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Services;
public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public BrandService(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }
    public async Task Create(BrandDto brandDto)
    {
        var brand = _mapper.Map<Brand>(brandDto);

        await _brandRepository.Create(brand);
    }
}