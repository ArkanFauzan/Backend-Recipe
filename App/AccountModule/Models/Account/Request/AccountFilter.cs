using System.ComponentModel.DataAnnotations;
using RecipeApi.BaseModule.Models.Base;

namespace RecipeApi.AccountModule.Models.Account;

public class AccountFilter : BaseFilter
{
    [EnumDataType(typeof(AccountOrder))]
    public AccountOrder order { get; set; }
}