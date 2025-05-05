
using RecipeApi.RecipeModule.Models.StepParameterTemplate;

namespace RecipeApi.RecipeModule.Models.StepParameter;

public class StepParameterResponseSingle
{
    public Guid Id { get; set; }
    public Guid StepId { get; set; }
    public required StepParameterTemplateResponse StepParameterTemplate { get; set; }
    public string? Value { get; set; }
    public string? Note { get; set; }
}