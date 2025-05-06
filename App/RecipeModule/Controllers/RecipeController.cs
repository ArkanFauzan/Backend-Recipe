using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Interfaces.Services;
using RecipeApi.RecipeModule.Models.Recipe;

namespace RecipeApi.RecipeModule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController(
    IRecipeService recipeService
    ) : ControllerBase
{
    private readonly IRecipeService _recipeService = recipeService;

    [Authorize("recipe.view")]
    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult<PaginatedResponse<RecipeResponse>>> GetPaginatedRecipe([FromQuery] RecipeFilter filter)
    {
        PaginatedResponse<RecipeResponse> recipes = await _recipeService.GetPaginatedRecipe(filter);
        return Ok(recipes);
    }

    [Authorize("recipe.view")]
    [HttpGet("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult<RecipeResponseSingle?>> GetRecipeById(Guid id)
    {
        RecipeResponseSingle? recipe = await _recipeService.GetRecipeById(id);
        if (recipe == null)
            return NotFound("Recipe not found");
            
        return Ok(new { message = "success", data = recipe });
    }

    [Authorize("recipe.view")]
    [HttpGet("{id}/WithAllStep")]
    [Produces("application/json")]
    public async Task<ActionResult<RecipeResponseSingle?>> GetRecipeByIdWithAllStep(Guid id)
    {
        RecipeResponseSingle? recipe = await _recipeService.GetRecipeByIdWithAllStep(id);
        if (recipe == null)
            return NotFound("Recipe not found");
            
        return Ok(new { message = "success", data = recipe });
    }

    [Authorize("recipe.view")]
    [HttpGet("{id}/WithAllStepAndParameter")]
    [Produces("application/json")]
    public async Task<ActionResult<RecipeResponseSingle?>> GetRecipeByIdWithAllStepAndParameter(Guid id)
    {
        RecipeResponseSingle? recipe = await _recipeService.GetRecipeByIdWithAllStepAndParameter(id);
        if (recipe == null)
            return NotFound("Recipe not found");
            
        return Ok(new { message = "success", data = recipe });
    }

    [Authorize]
    [HttpGet("select-data")]
    [Produces("application/json")]
    public async Task<ActionResult<List<SelectDataResponse>>> GetListRecipe([FromQuery] ListFilter filter)
    {
        List<SelectDataResponse> recipes = await _recipeService.GetListRecipe(filter);
        return Ok(new { message = "success", data = recipes });
    }

    [Authorize("recipe.create")]
    [HttpPost]
    [Produces("application/json")]
    public async Task<ActionResult<RecipeResponse>> CreateRecipe(CreateRecipeRequest model)
    {
        RecipeResponse recipe = await _recipeService.CreateRecipe(model);
        return Ok(new { message = "success", data = recipe });
    }

    [Authorize("recipe.update")]
    [HttpPut("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult<RecipeResponse>> UpdateRecipe(Guid id, UpdateRecipeRequest model)
    {
        RecipeResponse recipe = await _recipeService.UpdateRecipe(id, model);
        return Ok(new { message = "success", data = recipe });
    }

    [Authorize("recipe.delete")]
    [HttpDelete("{id}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeleteRecipe(Guid id)
    {
        await _recipeService.DeleteRecipe(id);
        return Ok(new { message = "success" });
    }

}