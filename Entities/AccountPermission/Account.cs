using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApi.Entities;

public class Account : BaseEntity
{
    [Column(TypeName = "varchar(150)")]
    public required string Username { get; set; }
    public required string FullName { get; set; }

    [Column(TypeName = "varchar(150)")]
    public string? Email { get; set; }
    [Column(TypeName = "varchar(150)")]
    public required string Password { get; set; } 
    public Guid RoleId { get; set; }
    public Role? Role { get; set; }
}