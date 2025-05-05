using System.ComponentModel.DataAnnotations;

namespace RecipeApi.RecipeModule.Models.Recipe;

public class CreateRecipeRequest
{
    [Required]
    public required string Name { get; set; }
}