using System.ComponentModel.DataAnnotations;
using RecipeApi.Enums;

namespace RecipeApi.RecipeModule.Models.StepParameter;

public class CreateStepParameterRequest
{
    [Required]
    public Guid StepId { get; set; }
    [Required]
    public Guid StepParameterTemplateId { get; set; }
    public string? Value { get; set; }
    public string? Note { get; set; }
    
}