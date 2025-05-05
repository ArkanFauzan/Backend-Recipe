using RecipeApi.Enums;

namespace RecipeApi.RecipeModule.Models.DataType;

public class DataTypeResponseSingle
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ParseTypeEnum ParseType { get; set; }
    public string? CustomRegex { get; set; }
}