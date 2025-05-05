

namespace RecipeApi.Entities;

public class StepParameter : BaseEntity
{
    public Guid StepId { get; set; }
    public required Step Step { get; set; }
    public Guid StepParameterTemplateId { get; set; }
    public required StepParameterTemplate StepParameterTemplate { get; set; }
    public string? Value { get; set; }
    public string? Note { get; set; }
}