using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class AddressRepository : BaseRepository<Address>, IAddressRepository
{
    public AddressRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }

    public async Task<Address> GetAddressAsync(string fullName, string firstLine, string? secondLine, string postalCode, string city)
    {
        var address = await DbContext.Addresses.FirstOrDefaultAsync(a => a.IsActive == true &&
                                                                         a.FullName == fullName &&
                                                                         a.FirstLine == firstLine &&
                                                                         a.SecondLine == secondLine &&
                                                                         a.PostalCode == postalCode &&
                                                                         a.City == city);

        if (address == null)
        {
            address = new Address
            {
                FullName = fullName,
                FirstLine = firstLine,
                SecondLine = secondLine,
                PostalCode = postalCode,
                City = city
            };
            await CreateAsync(address);
        }

        address = await GetAsync(address);

        return address!;
    }

    public override async Task CreateAsync(Address address)
    {
        var currentUser = UserContext.GetCurrentUser();


        address.CreatedById = currentUser?.Id;
        DbContext.Add(address);
        await DbContext.SaveChangesAsync();
    }
}
