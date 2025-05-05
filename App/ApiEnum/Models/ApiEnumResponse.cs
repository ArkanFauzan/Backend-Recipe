
namespace RecipeApi.ApiEnum.Models;

public class ApiEnumResponse
{
    public int Value { get; set; }  // ex: 0, 1, 2, etc
    public required string Code { get; set; } // ex: CUSTOM_REGEX
    public required string Label { get; set; } // ex: Custom Regex
}
