namespace SmellIt.Domain.Models;

public class CurrentUser
{
    public CurrentUser(string id, string email, IEnumerable<string> roles)
    {
        Roles = roles;
        Id = id;
        Email = email;
    }

    public string Id { get; set; }
    public string Email { get; set; }
    public IEnumerable<string> Roles { get; set; }

    public bool IsInRole(string role) => Roles.Contains(role);
}