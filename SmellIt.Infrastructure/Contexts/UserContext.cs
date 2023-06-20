using Microsoft.AspNetCore.Http;
using SmellIt.Domain.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Persistence;

namespace SmellIt.Infrastructure.Contexts;

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly SmellItDbContext _dbContext;

    public UserContext(IHttpContextAccessor httpContextAccessor, SmellItDbContext dbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _dbContext = dbContext;
    }

    public CurrentUser? GetCurrentUser()
    {
        var user = _httpContextAccessor?.HttpContext?.User;

        if (user == null)
        {
            throw new InvalidOperationException("Context user is not present");
        }

        if (user.Identity?.IsAuthenticated == false)
        {
            return null;
        }
        

        var id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c=>c.Value);

        return new CurrentUser(id, email, roles);
    }
    public async Task<IdentityUser> GetUser(string email)
    {
        return await _dbContext.Users.FirstAsync(u => u.Email == email);
    }
}