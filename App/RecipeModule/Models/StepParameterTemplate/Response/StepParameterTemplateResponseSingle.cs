using RecipeApi.Enums;
using RecipeApi.RecipeModule.Models.DataType;

namespace RecipeApi.RecipeModule.Models.StepParameterTemplate;

public class StepParameterTemplateResponseSingle
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required DataTypeResponse DataType { get; set; }
    public string? Description { get; set; }
}