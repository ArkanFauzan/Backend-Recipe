using System.ComponentModel.DataAnnotations;

namespace RecipeApi.RecipeModule.Models.Step;

public class ArrangeStepOrderRequest
{
    [Required]
    public Guid RecipeId { get; set; }
    public Guid? ParentId { get; set; }
    [Required]
    public List<Guid> StepIdsOrder { get; set; } = [];
}