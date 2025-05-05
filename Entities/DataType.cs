using RecipeApi.Enums;

namespace RecipeApi.Entities;

public class DataType : BaseEntity
{
    public required string Name { get; set; }
    public ParseTypeEnum ParseType { get; set; }
    public string? CustomRegex { get; set; }
}