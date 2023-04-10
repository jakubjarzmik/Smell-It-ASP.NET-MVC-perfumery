using SmellIt.Application.Dtos;

namespace SmellIt.Application.Services.Interfaces;
public interface IBrandService
{
    Task Create(BrandDto brand);
}
