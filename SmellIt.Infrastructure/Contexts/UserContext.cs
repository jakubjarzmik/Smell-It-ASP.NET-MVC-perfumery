using Microsoft.AspNetCore.Http;
using SmellIt.Domain.Models;
using System.Security.Claims;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Infrastructure.Contexts;

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public CurrentUser? GetCurrentUser()
    {
        var user = _httpContextAccessor?.HttpContext?.User;

        if (user == null)
        {
            throw new InvalidOperationException("User null reference");
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
}