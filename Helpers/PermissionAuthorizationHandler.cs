using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;

namespace RecipeApi.Helpers;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly AppDbContext _context;

    public PermissionAuthorizationHandler(AppDbContext context)
    {
        _context = context;
    }

    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier) ?? context.User.FindFirst("sub");
        if (userIdClaim == null) return;

        var accountId = Guid.Parse(userIdClaim.Value);

        var hasPermission = await _context.Accounts
            .Where(a => a.Id == accountId)
            .Include(a => a.Role)
                .ThenInclude(r => r.RolePermissionMethods)
                    .ThenInclude(rpm => rpm.PermissionMethod)
                        .ThenInclude(pm => pm.Permission)
            .AnyAsync(a => a.Role.RolePermissionMethods
                .Any(rpm => (rpm.PermissionMethod.Permission.ControllerName + "." +
                             rpm.PermissionMethod.Method).ToLower() == requirement.Permission.ToLower()));

        if (hasPermission)
        {
            context.Succeed(requirement);
        }
    }
}