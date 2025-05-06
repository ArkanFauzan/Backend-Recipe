using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.AccountModule.Interfaces.Services;
using RecipeApi.AccountModule.Models.Role;

namespace RecipeApi.AccountModule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController(
    IRoleService roleService
    ) : ControllerBase
{
    private readonly IRoleService _roleService = roleService;

    [Authorize]
    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult<PaginatedResponse<RoleResponse>>> GetPaginatedRole([FromQuery] RoleFilter filter)
    {
        PaginatedResponse<RoleResponse> roles = await _roleService.GetPaginatedRole(filter);
        return Ok(roles);
    }

    [Authorize]
    [HttpGet("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult<RoleResponseSingle?>> GetRoleById(Guid id)
    {
        RoleResponseSingle? role = await _roleService.GetRoleById(id);
        if (role == null)
            return NotFound("Role not found");
            
        return Ok(new { message = "success", data = role });
    }

    [Authorize]
    [HttpGet("select-data")]
    [Produces("application/json")]
    public async Task<ActionResult<List<SelectDataResponse>>> GetListRole([FromQuery] ListFilter filter)
    {
        List<SelectDataResponse> roles = await _roleService.GetListRole(filter);
        return Ok(new { message = "success", data = roles });
    }

    // [Authorize("role.create")]
    // [HttpPost]
    // [Produces("application/json")]
    // public async Task<ActionResult<RoleResponse>> CreateRole(CreateRoleRequest model)
    // {
    //     RoleResponse role = await _roleService.CreateRole(model);
    //     return Ok(new { message = "success", data = role });
    // }

    // [Authorize("role.update")]
    // [HttpPut("{id}")]
    // [Produces("application/json")]
    // public async Task<ActionResult<RoleResponse>> UpdateRole(Guid id, UpdateRoleRequest model)
    // {
    //     RoleResponse role = await _roleService.UpdateRole(id, model);
    //     return Ok(new { message = "success", data = role });
    // }

    // [Authorize("role.delete")]
    // [HttpDelete("{id}")]
    // [Produces("application/json")]
    // public async Task<IActionResult> DeleteRole(Guid id)
    // {
    //     await _roleService.DeleteRole(id);
    //     return Ok(new { message = "success" });
    // }

}