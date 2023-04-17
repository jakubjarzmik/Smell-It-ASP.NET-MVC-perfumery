using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Domain.Entities;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Seeders
{
    public class UserSeeder : ISeeder
    {
        private readonly SmellItDbContext _dbContext;

        public UserSeeder(SmellItDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (!_dbContext.Users.Any())
            {
                var address = new Address
                {
                    Street = "Robotnicza 91",
                    PostalCode = "30-545",
                    City = "Kraków",
                    Country = "Polska",
                    CreatedById = null,
                };
                address.EncodeName();
                _dbContext.Addresses.Add(address);
                var user = new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "jdoe@email.com",
                    Login = "jdoe",
                    Password = "qwe",
                    Address = address,
                    IsAdmin = true
                };
                user.EncodeName();
                await _dbContext.Users.AddAsync(user);
            }
        }
    }
}
