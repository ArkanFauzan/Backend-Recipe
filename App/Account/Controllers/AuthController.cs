using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RecipeApi.Helpers;
using RecipeApi.Data;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Account.Models;

namespace RecipeApi.Account.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly JwtSettings _jwtSettings;

    public AuthController(AppDbContext context, IOptions<JwtSettings> jwtSettings)
    {
        _context = context;
        _jwtSettings = jwtSettings.Value;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var account = await _context.Accounts
            .Include(a => a.Role)
            .FirstOrDefaultAsync(a => a.Username == request.Username);

        if (account == null || !BCrypt.Net.BCrypt.Verify(request.Password, account.Password))
            return Unauthorized("Invalid username or password");

        var token = JwtHelper.GenerateToken(account.Id, _jwtSettings);

        return Ok(new { token });
    }
}