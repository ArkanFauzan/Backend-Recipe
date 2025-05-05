namespace RecipeApi.Entities;

public class Recipe : BaseEntity
{
    public required string Name { get; set; }

    public ICollection<Step> Steps { get; set; } = [];
}
