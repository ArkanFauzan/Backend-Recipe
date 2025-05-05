using System.ComponentModel.DataAnnotations;
using RecipeApi.Enums;

namespace RecipeApi.RecipeModule.Models.DataType;

public class UpdateDataTypeRequest
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public ParseTypeEnum ParseType { get; set; }
    public string? CustomRegex { get; set; }
}
