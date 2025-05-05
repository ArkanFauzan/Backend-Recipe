using System.ComponentModel;
using System.Text.Json.Serialization;

namespace RecipeApi.RecipeModule.Models.Recipe;

[DefaultValue(Newest)]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RecipeOrder
{
    Newest,
    Name
}