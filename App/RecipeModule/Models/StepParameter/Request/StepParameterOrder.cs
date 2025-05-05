using System.ComponentModel;
using System.Text.Json.Serialization;

namespace RecipeApi.RecipeModule.Models.StepParameter;

[DefaultValue(Newest)]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StepParameterOrder
{
    Newest,
    Name
}