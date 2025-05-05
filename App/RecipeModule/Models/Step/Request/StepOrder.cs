using System.ComponentModel;
using System.Text.Json.Serialization;

namespace RecipeApi.RecipeModule.Models.Step;

[DefaultValue(Newest)]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StepOrder
{
    Newest,
    Name
}