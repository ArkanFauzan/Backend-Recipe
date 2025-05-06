
namespace RecipeApi.Entities;
public class PermissionMethod : BaseEntity
{
    public required string Method { get; set; } // ex: View / Create / Update / Delete 
    public Guid PermissionId { get; set; }
    public Permission? Permission { get; set; }
}