using Microsoft.AspNetCore.Mvc;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Interfaces.Services;
using RecipeApi.RecipeModule.Models.Step;

namespace RecipeApi.RecipeModule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StepController(
    IStepService stepService
    ) : ControllerBase
{
    private readonly IStepService _stepService = stepService;

    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult<PaginatedResponse<StepResponse>>> GetPaginatedStep([FromQuery] StepFilter filter)
    {
        PaginatedResponse<StepResponse> steps = await _stepService.GetPaginatedStep(filter);
        return Ok(steps);
    }

    [HttpGet("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult<StepResponseSingle?>> GetStepById(Guid id)
    {
        StepResponseSingle? step = await _stepService.GetStepById(id);
        if (step == null)
            return NotFound("Step not found");
            
        return Ok(new { message = "success", data = step });
    }

    [HttpGet("select-data")]
    [Produces("application/json")]
    public async Task<ActionResult<List<SelectDataResponse>>> GetListStep([FromQuery] ListFilter filter)
    {
        List<SelectDataResponse> steps = await _stepService.GetListStep(filter);
        return Ok(new { message = "success", data = steps });
    }

    [HttpPost]
    [Produces("application/json")]
    public async Task<ActionResult<StepResponse>> CreateStep(CreateStepRequest model)
    {
        StepResponse step = await _stepService.CreateStep(model);
        return Ok(new { message = "success", data = step });
    }

    [HttpPut("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult<StepResponse>> UpdateStep(Guid id, UpdateStepRequest model)
    {
        StepResponse step = await _stepService.UpdateStep(id, model);
        return Ok(new { message = "success", data = step });
    }

    [HttpDelete("{id}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeleteStep(Guid id)
    {
        await _stepService.DeleteStep(id);
        return Ok(new { message = "success" });
    }

}