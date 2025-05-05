
using RecipeApi.RecipeModule.Models.Recipe;

namespace RecipeApi.RecipeModule.Models.Step;

public class StepResponseSingle
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid RecipeId { get; set; }
    public Guid? ParentId { get; set; }
    public List<StepResponseSingle> Children { get; set; } = [];
}