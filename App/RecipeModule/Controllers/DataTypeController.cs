using Microsoft.AspNetCore.Mvc;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Interfaces.Services;
using RecipeApi.RecipeModule.Models.DataType;

namespace RecipeApi.RecipeModule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataTypeController(
    IDataTypeService dataTypeService
    ) : ControllerBase
{
    private readonly IDataTypeService _dataTypeService = dataTypeService;

    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult<PaginatedResponse<DataTypeResponse>>> GetPaginatedDataType([FromQuery] DataTypeFilter filter)
    {
        PaginatedResponse<DataTypeResponse> dataTypes = await _dataTypeService.GetPaginatedDataType(filter);
        return Ok(dataTypes);
    }

    [HttpGet("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult<DataTypeResponseSingle?>> GetDataTypeById(Guid id)
    {
        DataTypeResponseSingle? dataType = await _dataTypeService.GetDataTypeById(id);
        if (dataType == null)
            return NotFound("DataType not found");
            
        return Ok(new { message = "success", data = dataType });
    }

    [HttpGet("select-data")]
    [Produces("application/json")]
    public async Task<ActionResult<List<SelectDataResponse>>> GetListDataType([FromQuery] ListFilter filter)
    {
        List<SelectDataResponse> dataTypes = await _dataTypeService.GetListDataType(filter);
        return Ok(new { message = "success", data = dataTypes });
    }

    [HttpPost]
    [Produces("application/json")]
    public async Task<ActionResult<DataTypeResponse>> CreateDataType(CreateDataTypeRequest model)
    {
        DataTypeResponse dataType = await _dataTypeService.CreateDataType(model);
        return Ok(new { message = "success", data = dataType });
    }

    [HttpPut("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult<DataTypeResponse>> UpdateDataType(Guid id, UpdateDataTypeRequest model)
    {
        DataTypeResponse dataType = await _dataTypeService.UpdateDataType(id, model);
        return Ok(new { message = "success", data = dataType });
    }

    [HttpDelete("{id}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeleteDataType(Guid id)
    {
        await _dataTypeService.DeleteDataType(id);
        return Ok(new { message = "success" });
    }

}