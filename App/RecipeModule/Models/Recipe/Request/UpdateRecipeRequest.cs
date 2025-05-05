using System.ComponentModel.DataAnnotations;

namespace RecipeApi.RecipeModule.Models.Recipe;

public class UpdateRecipeRequest
{
    [Required]
    public required string Name { get; set; }
}