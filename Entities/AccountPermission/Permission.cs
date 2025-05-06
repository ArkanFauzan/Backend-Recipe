using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApi.Entities;

public class Permission : BaseEntity
{
    [Column(TypeName = "varchar(64)")]
    public required string Name { get; set; } // ex: Step Parameter Management 
    [Column(TypeName = "varchar(64)")]
    public required string ControllerName { get; set; } // ex: step-parameter 
    public int Order { get; set; } // for ordering permission  

    public virtual List<PermissionMethod> PermissionMethods { get; set; } = [];
}