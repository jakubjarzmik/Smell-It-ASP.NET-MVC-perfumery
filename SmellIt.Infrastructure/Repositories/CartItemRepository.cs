using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
{
    public CartItemRepository(SmellItDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<IEnumerable<CartItem>> GetBySessionAsync(string session)
        => await DbContext.CartItems.Where(ci => ci.IsActive && ci.Session.Equals(session)).OrderByDescending(ci => ci.CreatedAt).ToListAsync();

    public async Task<CartItem?> GetBySessionAndProductEncodedNameAsync(string session, string productEncodedName)
        => await DbContext.CartItems.FirstOrDefaultAsync(ci => ci.IsActive && ci.Session.Equals(session) && ci.Product.EncodedName!.Equals(productEncodedName));

}
