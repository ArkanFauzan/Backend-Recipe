using System.ComponentModel.DataAnnotations;
using RecipeApi.BaseModule.Models.Base;

namespace RecipeApi.RecipeModule.Models.StepParameterTemplate;

public class StepParameterTemplateFilter : BaseFilter
{
    [EnumDataType(typeof(StepParameterTemplateOrder))]
    public StepParameterTemplateOrder order { get; set; }
}