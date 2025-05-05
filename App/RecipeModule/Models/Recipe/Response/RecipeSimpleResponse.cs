
namespace RecipeApi.RecipeModule.Models.Recipe;

public class RecipeSimpleResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}