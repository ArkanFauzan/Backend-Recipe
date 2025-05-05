

namespace RecipeApi.Entities;

public class StepParameter : BaseEntity
{
    public Guid StepId { get; set; }
    public required Step Step { get; set; }
    public Guid TemplateId { get; set; }
    public required StepParameterTemplate Template { get; set; }
    public string? Value { get; set; }
    public string? Note { get; set; }
}