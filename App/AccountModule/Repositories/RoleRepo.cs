using Microsoft.EntityFrameworkCore;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.AccountModule.Interfaces.Repositories;
using RecipeApi.Entities;
using RecipeApi.Helpers;
using RecipeApi.Data;
using RecipeApi.AccountModule.Models.Role;

namespace RecipeApi.AccountModule.Repositories;

public class RoleRepo (
    AppDbContext context
    ) : IRoleRepo
{
    public readonly AppDbContext _context = context;

    public async Task<List<Role>> GetAllRoles(ListFilter filter)
    {
        IQueryable<Role> query = _context.Roles.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Query))
        {
            query = query.Where(x => EF.Functions.Like(x.RoleName, $"%{filter.Query}%"));
        }

        if (filter.Limit > 0)
        {
            query = query.Take((int)filter.Limit);
        }

        List<Role> types = await query.ToListAsync();

        if (!string.IsNullOrEmpty(filter.Includes))
        {
            List<Guid> guids = SiteHelper.ParseGuids(filter.Includes);

            types.AddRange(await getRoles(guids));
        }

        return types.Distinct().ToList();
    }

    public async Task<(List<Role>, int, int)> GetPaginatedRoles(RoleFilter roleFilter, int pageIndex, int pageSize)
    {
        IQueryable<Role> query = _context.Roles.AsQueryable();

        if (roleFilter.query != null)
        {
            query = query.Where(x => EF.Functions.Like(x.RoleName, $"%{roleFilter.query}%"));
        }

        query = roleFilter.order switch
        {
            RoleOrder.RoleName => query.OrderBy(x => x.RoleName),
            _ => query.OrderByDescending(x => x.Created)
        };

        List<Role> result = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        int count = await query.CountAsync();
        int totalPages = (int)Math.Ceiling(count / (double)pageSize);

        return (result, count, totalPages);
    }

    public async Task<Role?> GetRole(Guid id)
    {
        return await _context.Roles.FirstOrDefaultAsync( x => x.Id == id);
    }

    public async Task<Role?> GetFullRole(Guid id)
    {
        return await _context.Roles.FirstOrDefaultAsync( x => x.Id == id);
    }

    public async Task<bool> CheckRoleIdExist(Guid id)
    {
        return await _context.Roles.AnyAsync(x => x.Id == id);
    }
    
    public async Task CreateRole(Role role)
    {
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRole(Role role)
    {
        _context.Roles.Update(role);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRole(Role role)
    {
        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
    }

    private async Task<List<Role>> getRoles(List<Guid> ids)
    {
        return await _context.Roles.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}