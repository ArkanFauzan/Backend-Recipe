using System.ComponentModel.DataAnnotations;
using RecipeApi.BaseModule.Models.Base;

namespace RecipeApi.AccountModule.Models.Role;

public class RoleFilter : BaseFilter
{
    [EnumDataType(typeof(RoleOrder))]
    public RoleOrder order { get; set; }
}