using System.ComponentModel;
using System.Text.Json.Serialization;

namespace RecipeApi.RecipeModule.Models.StepParameterTemplate;

[DefaultValue(Newest)]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StepParameterTemplateOrder
{
    Newest,
    Name
}