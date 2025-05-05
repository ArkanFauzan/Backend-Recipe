using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecipeApi.Enums;

[DefaultValue(TEXT)]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ParseTypeEnum
{
    [Display(Name = "Text")]
    TEXT = 0,
    [Display(Name = "Float")]
    FLOAT = 1,
    [Display(Name = "Integer")]
    INTEGER = 2,
    [Display(Name = "Boolean")]
    BOOLEAN = 3,
    [Display(Name = "Date")]
    DATE = 4,
    [Display(Name = "Custom Regex")]
    CUSTOM_REGEX = 5
}