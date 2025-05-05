
using RecipeApi.RecipeModule.Models.Step;

namespace RecipeApi.RecipeModule.Models.Recipe;

public class RecipeResponseSingle
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<StepResponseSingle> Steps { get; set; } = [];
}