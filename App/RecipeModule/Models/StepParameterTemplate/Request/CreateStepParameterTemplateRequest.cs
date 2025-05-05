using System.ComponentModel.DataAnnotations;
using RecipeApi.Enums;

namespace RecipeApi.RecipeModule.Models.StepParameterTemplate;

public class CreateStepParameterTemplateRequest
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public Guid DataTypeId { get; set; }
    public string? Description { get; set; }
}