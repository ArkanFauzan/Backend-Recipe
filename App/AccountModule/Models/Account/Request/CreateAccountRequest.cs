using System.ComponentModel.DataAnnotations;
using RecipeApi.Enums;

namespace RecipeApi.AccountModule.Models.Account;

public class CreateAccountRequest
{
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string FullName { get; set; }
    [Required]
    public required string Password { get; set; }
    [Required]
    public Guid RoleId { get; set; }
    public string? Email { get; set; }
}