using SmellIt.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmellIt.Infrastructure.Seeders
{
    public class Seeder
    {
        private readonly SmellItDbContext _dbContext;
        private readonly List<ISeeder> _seeders;

        public Seeder(SmellItDbContext dbContext)
        {
            _dbContext = dbContext;
            _seeders = new List<ISeeder>()
            {
                new UserSeeder(dbContext),
                new ProductSeeder(dbContext),
            };
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                foreach (var seeder in _seeders)
                {
                    await seeder.Seed();
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
