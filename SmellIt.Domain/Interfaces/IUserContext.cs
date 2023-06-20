using Microsoft.AspNetCore.Identity;
using SmellIt.Domain.Models;

namespace SmellIt.Domain.Interfaces;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
    Task<IdentityUser> GetUser(string email);
}