namespace SmellIt.Domain.Models;

public class CurrentUser
{
    public CurrentUser(string id, string email)
    {
        Id = id;
        Email = email;
    }
    public string Id { get; set; }
    public string Email { get; set; }
}