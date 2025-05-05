using System.ComponentModel.DataAnnotations;
using RecipeApi.BaseModule.Models.Base;

namespace RecipeApi.RecipeModule.Models.Step;

public class StepFilter : BaseFilter
{
    [EnumDataType(typeof(StepOrder))]
    public StepOrder order { get; set; }
}