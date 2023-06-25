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

    public async Task<Address?> GetAddressAsync(string fullName, string firstLine, string secondLine, string postalCode, string city)
        => await DbContext.Addresses.FirstOrDefaultAsync(a => a.IsActive == true &&
                                                              a.FullName == fullName &&
                                                              a.FirstLine == firstLine &&
                                                              a.SecondLine == secondLine &&
                                                              a.PostalCode == postalCode &&
                                                              a.City == city);
    public Address? GetAddress(string fullName, string firstLine, string secondLine, string postalCode, string city)
        => DbContext.Addresses.FirstOrDefault(a => a.IsActive == true &&
                                                              a.FullName == fullName &&
                                                              a.FirstLine == firstLine &&
                                                              a.SecondLine == secondLine &&
                                                              a.PostalCode == postalCode &&
                                                              a.City == city);
    public override async Task CreateAsync(Address cartItem)
    {
        var currentUser = UserContext.GetCurrentUser();


        cartItem.CreatedById = currentUser?.Id;
        DbContext.Add(cartItem);
        await DbContext.SaveChangesAsync();
    }
}
