using System.ComponentModel;
using System.Text.Json.Serialization;

namespace RecipeApi.AccountModule.Models.Account;

[DefaultValue(Newest)]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AccountOrder
{
    Newest,
    FullName
}