
using Microsoft.AspNetCore.Mvc;
using RecipeApi.ApiEnum.Models;
using RecipeApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace RecipeApi.ApiEnum.Controllers;

[ApiController]
[Route("api/enum")]
public class ApiEnumController : ControllerBase
{
    /// <summary>
    /// Get parse type enum
    /// </summary>
    /// <returns></returns>
    [HttpGet("parse-type-enum")]
    [Produces("application/json", "application/xml", Type = typeof(List<ApiEnumResponse>))]
    public IActionResult GetParseTypeEnum()
    {
        List<ApiEnumResponse> enumList = getEnumList<ParseTypeEnum>();
        return Ok(enumList);
    }

    private List<ApiEnumResponse> getEnumList<T>() where T : Enum 
    {
        return [.. Enum.GetValues(typeof(T))
            .Cast<T>()
            .Select(e => new ApiEnumResponse
            {
                Value = Convert.ToInt32(e),
                Code = e.ToString(),
                Label = getEnumDisplayName(e)
            })]; 
    }

    private string getEnumDisplayName<T>(T enumValue) where T : Enum
    {
        var displayAttribute = enumValue.GetType()
            .GetMember(enumValue.ToString())
            .FirstOrDefault()?
            .GetCustomAttribute<DisplayAttribute>();

        return displayAttribute?.Name ?? enumValue.ToString();
    }

}
