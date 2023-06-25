using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces.Abstract;

namespace SmellIt.Domain.Interfaces;
public interface IAddressRepository : IBaseRepository<Address>
{
    Task<Address?> GetAddressAsync(string fullName, string firstLine, string secondLine, string postalCode, string city);
    Address? GetAddress(string fullName, string firstLine, string secondLine, string postalCode, string city);
}
