
using RecipeApi.Enums;

namespace RecipeApi.AccountModule.Models.Role;

public class RoleResponse
{
    public Guid Id { get; set; }
    public required string RoleName { get; set; }
    public required string Description { get; set; }
}