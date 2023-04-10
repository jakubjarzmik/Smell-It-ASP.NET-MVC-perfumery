using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Domain.Entities;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Seeders
{
    public class AddressSeeder : ISeeder
    {
        private readonly SmellItDbContext _dbContext;

        public AddressSeeder(SmellItDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (!_dbContext.Addresses.Any())
            {
                List<Address> data = new()
                {
                    new Address { Street = "Robotnicza 91", PostalCode = "30-545", City = "Kraków", Country = "Polska", CreatedById = _dbContext.Users.FirstOrDefault() !.Id }
                };
                await _dbContext.Addresses.AddRangeAsync(data);
                await _dbContext.SaveChangesAsync();
                _dbContext.Users.FirstOrDefault()!.AddressId = _dbContext.Addresses.FirstOrDefault()!.Id;
            }
        }
    }
}
