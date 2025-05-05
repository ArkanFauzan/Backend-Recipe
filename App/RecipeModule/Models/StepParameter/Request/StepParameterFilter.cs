using System.ComponentModel.DataAnnotations;
using RecipeApi.BaseModule.Models.Base;

namespace RecipeApi.RecipeModule.Models.StepParameter;

public class StepParameterFilter : BaseFilter
{
    [EnumDataType(typeof(StepParameterOrder))]
    public StepParameterOrder order { get; set; }
}