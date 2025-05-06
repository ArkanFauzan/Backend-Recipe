using RecipeApi.AccountModule.Models.Role;

namespace RecipeApi.AccountModule.Models.Account;

public class AccountResponseSingle
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required string FullName { get; set; }
    public required RoleResponse Role { get; set; }
    public string? Email { get; set; }
}