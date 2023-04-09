using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface IBrandRepository
{
    Task Create(Brand brand);
}
