using System.ComponentModel.DataAnnotations;

namespace RecipeApi.RecipeModule.Models.Step;

public class UpdateStepRequest
{
    [Required]
    public required string Name { get; set; }
}