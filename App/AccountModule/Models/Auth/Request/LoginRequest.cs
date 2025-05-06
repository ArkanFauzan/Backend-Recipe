

using System.ComponentModel.DataAnnotations;

namespace RecipeApi.AccountModule.Models.Auth;

public class LoginRequest
{
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Password { get; set; }
}