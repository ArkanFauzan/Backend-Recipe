

namespace RecipeApi.Entities;

public class StepParameterTemplate : BaseEntity
{
    public required string Name { get; set; }
    public Guid DataTypeId { get; set; }
    public required DataType DataType { get; set; }
    public string? Description { get; set; }
}