using System.ComponentModel.DataAnnotations;
using RecipeApi.BaseModule.Models.Base;

namespace RecipeApi.RecipeModule.Models.DataType;

public class DataTypeFilter : BaseFilter
{
    [EnumDataType(typeof(DataTypeOrder))]
    public DataTypeOrder order { get; set; }
}