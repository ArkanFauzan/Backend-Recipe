using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.AccountModule.Interfaces.Services;
using RecipeApi.AccountModule.Models.Account;

namespace RecipeApi.AccountModule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(
    IAccountService accountService
    ) : ControllerBase
{
    private readonly IAccountService _accountService = accountService;

    [Authorize("account.view")]
    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult<PaginatedResponse<AccountResponse>>> GetPaginatedAccount([FromQuery] AccountFilter filter)
    {
        PaginatedResponse<AccountResponse> accounts = await _accountService.GetPaginatedAccount(filter);
        return Ok(accounts);
    }

    [Authorize("account.view")]
    [HttpGet("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult<AccountResponseSingle?>> GetAccountById(Guid id)
    {
        AccountResponseSingle? account = await _accountService.GetAccountById(id);
        if (account == null)
            return NotFound("Account not found");
            
        return Ok(new { message = "success", data = account });
    }

    [Authorize]
    [HttpGet("select-data")]
    [Produces("application/json")]
    public async Task<ActionResult<List<SelectDataResponse>>> GetListAccount([FromQuery] ListFilter filter)
    {
        List<SelectDataResponse> accounts = await _accountService.GetListAccount(filter);
        return Ok(new { message = "success", data = accounts });
    }

    [Authorize("account.create")]
    [HttpPost]
    [Produces("application/json")]
    public async Task<ActionResult<AccountResponse>> CreateAccount(CreateAccountRequest model)
    {
        AccountResponse account = await _accountService.CreateAccount(model);
        return Ok(new { message = "success", data = account });
    }

    [Authorize("account.update")]
    [HttpPut("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult<AccountResponse>> UpdateAccount(Guid id, UpdateAccountRequest model)
    {
        AccountResponse account = await _accountService.UpdateAccount(id, model);
        return Ok(new { message = "success", data = account });
    }

    [Authorize("account.delete")]
    [HttpDelete("{id}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeleteAccount(Guid id)
    {
        await _accountService.DeleteAccount(id);
        return Ok(new { message = "success" });
    }

}