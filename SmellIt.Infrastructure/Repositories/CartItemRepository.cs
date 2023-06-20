using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories.Abstract;

namespace SmellIt.Infrastructure.Repositories;
public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
{
    public CartItemRepository(SmellItDbContext dbContext, IUserContext userContext) : base(dbContext, userContext)
    {
    }

    public async Task<IEnumerable<CartItem>> GetBySessionAsync(string session)
        => await DbContext.CartItems.Where(ci => ci.IsActive && ci.Session.Equals(session)).OrderByDescending(ci => ci.CreatedAt).ToListAsync();

    public async Task<IEnumerable<CartItem>> GetByUserAsync(string userId)
        => await DbContext.CartItems.Where(ci => ci.IsActive &&  ci.UserId == userId).OrderByDescending(ci => ci.CreatedAt).ToListAsync();

    public async Task<CartItem?> GetBySessionAndProductEncodedNameAsync(string session, string productEncodedName)
        => await DbContext.CartItems.FirstOrDefaultAsync(ci => ci.IsActive && ci.Session.Equals(session) && ci.Product.EncodedName!.Equals(productEncodedName));

    public async Task<CartItem?> GetBySessionOrUserAndProductEncodedNameAsync(string session, string userId, string productEncodedName)
        => await DbContext.CartItems.FirstOrDefaultAsync(ci => ci.IsActive && (ci.Session.Equals(session) || ci.UserId == userId) && ci.Product.EncodedName!.Equals(productEncodedName));

    public override async Task CreateAsync(CartItem cartItem)
    {
        var currentUser = UserContext.GetCurrentUser();

        cartItem.CreatedById = currentUser?.Id;
        cartItem.UserId = currentUser?.Id;
        DbContext.Add(cartItem);
        await DbContext.SaveChangesAsync();
    }
    public override async Task DeleteAsync(CartItem cartItem)
    {
        var currentUser = UserContext.GetCurrentUser();

        cartItem.DeletedById = currentUser?.Id;
        cartItem.IsActive = false;
        cartItem.DeletedAt = DateTime.Now;
        await DbContext.SaveChangesAsync();
    }
}
