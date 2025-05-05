using Microsoft.AspNetCore.Mvc;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Interfaces.Services;
using RecipeApi.RecipeModule.Models.StepParameterTemplate;

namespace RecipeApi.RecipeModule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StepParameterTemplateController(
    IStepParameterTemplateService stepParameterTemplateService
    ) : ControllerBase
{
    private readonly IStepParameterTemplateService _stepParameterTemplateService = stepParameterTemplateService;

    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult<PaginatedResponse<StepParameterTemplateResponse>>> GetPaginatedStepParameterTemplate([FromQuery] StepParameterTemplateFilter filter)
    {
        PaginatedResponse<StepParameterTemplateResponse> stepParameterTemplates = await _stepParameterTemplateService.GetPaginatedStepParameterTemplate(filter);
        return Ok(stepParameterTemplates);
    }

    [HttpGet("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult<StepParameterTemplateResponseSingle?>> GetStepParameterTemplateById(Guid id)
    {
        StepParameterTemplateResponseSingle? stepParameterTemplate = await _stepParameterTemplateService.GetStepParameterTemplateById(id);
        if (stepParameterTemplate == null)
            return NotFound("StepParameterTemplate not found");
            
        return Ok(new { message = "success", data = stepParameterTemplate });
    }

    [HttpGet("select-data")]
    [Produces("application/json")]
    public async Task<ActionResult<List<SelectDataResponse>>> GetListStepParameterTemplate([FromQuery] ListFilter filter)
    {
        List<SelectDataResponse> stepParameterTemplates = await _stepParameterTemplateService.GetListStepParameterTemplate(filter);
        return Ok(new { message = "success", data = stepParameterTemplates });
    }

    [HttpPost]
    [Produces("application/json")]
    public async Task<ActionResult<StepParameterTemplateResponse>> CreateStepParameterTemplate(CreateStepParameterTemplateRequest model)
    {
        StepParameterTemplateResponse stepParameterTemplate = await _stepParameterTemplateService.CreateStepParameterTemplate(model);
        return Ok(new { message = "success", data = stepParameterTemplate });
    }

    [HttpPut("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult<StepParameterTemplateResponse>> UpdateStepParameterTemplate(Guid id, UpdateStepParameterTemplateRequest model)
    {
        StepParameterTemplateResponse stepParameterTemplate = await _stepParameterTemplateService.UpdateStepParameterTemplate(id, model);
        return Ok(new { message = "success", data = stepParameterTemplate });
    }

    [HttpDelete("{id}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeleteStepParameterTemplate(Guid id)
    {
        await _stepParameterTemplateService.DeleteStepParameterTemplate(id);
        return Ok(new { message = "success" });
    }

}