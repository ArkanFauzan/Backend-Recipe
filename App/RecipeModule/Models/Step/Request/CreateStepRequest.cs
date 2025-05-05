using System.ComponentModel.DataAnnotations;

namespace RecipeApi.RecipeModule.Models.Step;

public class CreateStepRequest
{
    [Required]
    public required string Name { get; set; }
    public Guid? RecipeId { get; set; }
    public Guid? ParentId { get; set; }
}