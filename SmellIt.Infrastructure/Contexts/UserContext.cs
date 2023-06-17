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

    public CurrentUser GetCurrentUser()
    {
        var user = _httpContextAccessor?.HttpContext?.User;
        if (user == null)
        {
            throw new InvalidOperationException("Context user is not present");
        }

        var id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;

        return new CurrentUser(id, email);
    }
}