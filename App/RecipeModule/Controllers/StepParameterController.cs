using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Interfaces.Services;
using RecipeApi.RecipeModule.Models.StepParameter;

namespace RecipeApi.RecipeModule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StepParameterController(
    IStepParameterService stepParameterService
    ) : ControllerBase
{
    private readonly IStepParameterService _stepParameterService = stepParameterService;

    [Authorize("step-parameter.view")]
    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult<PaginatedResponse<StepParameterResponse>>> GetPaginatedStepParameter([FromQuery] StepParameterFilter filter)
    {
        PaginatedResponse<StepParameterResponse> stepParameters = await _stepParameterService.GetPaginatedStepParameter(filter);
        return Ok(stepParameters);
    }

    [Authorize("step-parameter.view")]
    [HttpGet("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult<StepParameterResponseSingle?>> GetStepParameterById(Guid id)
    {
        StepParameterResponseSingle? stepParameter = await _stepParameterService.GetStepParameterById(id);
        if (stepParameter == null)
            return NotFound("StepParameter not found");
            
        return Ok(new { message = "success", data = stepParameter });
    }

    [Authorize]
    [HttpGet("select-data")]
    [Produces("application/json")]
    public async Task<ActionResult<List<SelectDataResponse>>> GetListStepParameter([FromQuery] ListFilter filter)
    {
        List<SelectDataResponse> stepParameters = await _stepParameterService.GetListStepParameter(filter);
        return Ok(new { message = "success", data = stepParameters });
    }

    [Authorize("step-parameter.create")]
    [HttpPost]
    [Produces("application/json")]
    public async Task<ActionResult<StepParameterResponse>> CreateStepParameter(CreateStepParameterRequest model)
    {
        StepParameterResponse stepParameter = await _stepParameterService.CreateStepParameter(model);
        return Ok(new { message = "success", data = stepParameter });
    }

    [Authorize("step-parameter.update")]
    [HttpPut("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult<StepParameterResponse>> UpdateStepParameter(Guid id, UpdateStepParameterRequest model)
    {
        StepParameterResponse stepParameter = await _stepParameterService.UpdateStepParameter(id, model);
        return Ok(new { message = "success", data = stepParameter });
    }

    [Authorize("step-parameter.delete")]
    [HttpDelete("{id}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeleteStepParameter(Guid id)
    {
        await _stepParameterService.DeleteStepParameter(id);
        return Ok(new { message = "success" });
    }

}