using System.ComponentModel;
using System.Text.Json.Serialization;

namespace RecipeApi.RecipeModule.Models.DataType;

[DefaultValue(Newest)]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DataTypeOrder
{
    Newest,
    Name
}