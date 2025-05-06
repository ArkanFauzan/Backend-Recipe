using Microsoft.AspNetCore.Authorization;
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

    [Authorize("step.view")]
    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult<PaginatedResponse<StepResponse>>> GetPaginatedStep([FromQuery] StepFilter filter)
    {
        PaginatedResponse<StepResponse> steps = await _stepService.GetPaginatedStep(filter);
        return Ok(steps);
    }

    [Authorize("step.view")]
    [HttpGet("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult<StepResponseSingle?>> GetStepById(Guid id)
    {
        StepResponseSingle? step = await _stepService.GetStepById(id);
        if (step == null)
            return NotFound("Step not found");
            
        return Ok(new { message = "success", data = step });
    }

    [Authorize("step.view")]
    [HttpGet("{id}/WithAllChildren")]
    [Produces("application/json")]
    public async Task<ActionResult<StepResponseSingle?>> GetStepByIdWithAllChildren(Guid id)
    {
        StepResponseSingle? step = await _stepService.GetStepByIdWithAllChildren(id);
        if (step == null)
            return NotFound("Step not found");
            
        return Ok(new { message = "success", data = step });
    }

    [Authorize("step.view")]
    [HttpGet("{id}/WithAllChildrenAndParameter")]
    [Produces("application/json")]
    public async Task<ActionResult<StepResponseSingle?>> GetStepByIdWithAllChildrenAndParameter(Guid id)
    {
        StepResponseSingle? step = await _stepService.GetStepByIdWithAllChildrenAndParameter(id);
        if (step == null)
            return NotFound("Step not found");
            
        return Ok(new { message = "success", data = step });
    }

    [Authorize]
    [HttpGet("select-data")]
    [Produces("application/json")]
    public async Task<ActionResult<List<SelectDataResponse>>> GetListStep([FromQuery] ListFilter filter)
    {
        List<SelectDataResponse> steps = await _stepService.GetListStep(filter);
        return Ok(new { message = "success", data = steps });
    }

    [Authorize("step.update")]
    [HttpPost("ArrangeStepOrder")]
    [Produces("application/json")]
    public async Task<ActionResult<StepResponse>> ArrangeStepOrder(ArrangeStepOrderRequest model)
    {
        List<StepResponse> steps = await _stepService.ArrangeStepOrder(model);
        return Ok(new { message = "success", data = steps });
    }

    [Authorize("step.create")]
    [HttpPost]
    [Produces("application/json")]
    public async Task<ActionResult<StepResponse>> CreateStep(CreateStepRequest model)
    {
        StepResponse step = await _stepService.CreateStep(model);
        return Ok(new { message = "success", data = step });
    }

    [Authorize("step.update")]
    [HttpPut("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult<StepResponse>> UpdateStep(Guid id, UpdateStepRequest model)
    {
        StepResponse step = await _stepService.UpdateStep(id, model);
        return Ok(new { message = "success", data = step });
    }

    [Authorize("step.delete")]
    [HttpDelete("{id}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeleteStep(Guid id)
    {
        await _stepService.DeleteStep(id);
        return Ok(new { message = "success" });
    }

}