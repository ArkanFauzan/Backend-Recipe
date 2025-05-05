using System.ComponentModel;

namespace RecipeApi.Entities;

public class Step : BaseEntity
{
    public required string Name { get; set; }
    public Guid RecipeId { get; set; }
    public required Recipe Recipe { get; set; }
    public Guid? ParentId { get; set; } // null for the first depth (directly under recipe)
    public Step? Parent { get; set; }
    public int Depth { get; set; } = 1; // Depth level of step
    
    public ICollection<Step> Children { get; set; } = [];
    public ICollection<StepParameter> StepParameters{ get; set; } = [];
}