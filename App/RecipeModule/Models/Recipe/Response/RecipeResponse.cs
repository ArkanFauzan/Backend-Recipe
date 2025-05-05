
namespace RecipeApi.RecipeModule.Models.Recipe;

public class RecipeResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}