namespace RecipeApi.Entities;

public class RolePermissionMethod : BaseEntity 
{
    public Guid RoleId { get; set; }
    public Role? Role { get; set; }
    public Guid PermissionMethodId { get; set; } 
    public PermissionMethod? PermissionMethod { get; set; } 

}