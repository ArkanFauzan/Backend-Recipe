using System.ComponentModel;
using System.Text.Json.Serialization;

namespace RecipeApi.Enums;

[DefaultValue(Active)]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AccountStatus
{
    Active,
    Locked,
    NonActive
}