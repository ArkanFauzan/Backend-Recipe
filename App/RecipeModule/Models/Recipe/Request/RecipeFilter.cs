using System.ComponentModel.DataAnnotations;
using RecipeApi.BaseModule.Models.Base;

namespace RecipeApi.RecipeModule.Models.Recipe;

public class RecipeFilter : BaseFilter
{
    [EnumDataType(typeof(RecipeOrder))]
    public RecipeOrder order { get; set; }
}