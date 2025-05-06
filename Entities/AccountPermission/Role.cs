using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApi.Entities;

public class Role : BaseEntity
{
    [Column(TypeName = "varchar(64)")]
    public required string RoleName { get; set; }
    public required string Description { get; set; }
    public List<RolePermissionMethod> RolePermissionMethods { get; set; } = [];
}