using System.ComponentModel.DataAnnotations;
using RecipeApi.Enums;

namespace RecipeApi.AccountModule.Models.Role;

public class CreateRoleRequest
{
    [Required]
    public required string RoleName { get; set; }
    [Required]
    public required string Description { get; set; }
}