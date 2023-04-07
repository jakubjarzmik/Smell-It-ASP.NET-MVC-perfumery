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
                List<User> data = new List<User>
                {
                    new User { FirstName = "John", LastName = "Doe", Email = "jdoe@email.com", Password = "qwe", IsAdmin = true}
                };
                await _dbContext.Users.AddRangeAsync(data);
            }
        }
    }
}
