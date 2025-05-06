using System.ComponentModel;
using System.Text.Json.Serialization;

namespace RecipeApi.AccountModule.Models.Role;

[DefaultValue(Newest)]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RoleOrder
{
    Newest,
    RoleName
}