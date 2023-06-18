using SmellIt.Domain.Models;

namespace SmellIt.Domain.Interfaces;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}