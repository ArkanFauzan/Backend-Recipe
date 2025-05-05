using Microsoft.EntityFrameworkCore;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Interfaces.Repositories;
using RecipeApi.Entities;
using RecipeApi.Helpers;
using RecipeApi.Data;
using RecipeApi.RecipeModule.Models.Step;

namespace RecipeApi.RecipeModule.Repositories;

public class StepRepo (
    AppDbContext context
    ) : IStepRepo
{
    public readonly AppDbContext _context = context;

    public async Task<List<Step>> GetAllSteps(ListFilter filter)
    {
        IQueryable<Step> query = _context.Steps.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Query))
        {
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{filter.Query}%"));
        }

        if (filter.Limit > 0)
        {
            query = query.Take((int)filter.Limit);
        }

        List<Step> types = await query.ToListAsync();

        if (!string.IsNullOrEmpty(filter.Includes))
        {
            List<Guid> guids = SiteHelper.ParseGuids(filter.Includes);

            types.AddRange(await getSteps(guids));
        }

        return types.Distinct().ToList();
    }

    public async Task<(List<Step>, int, int)> GetPaginatedSteps(StepFilter stepFilter, int pageIndex, int pageSize)
    {
        IQueryable<Step> query = _context.Steps.AsQueryable();

        if (stepFilter.query != null)
        {
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{stepFilter.query}%"));
        }

        query = stepFilter.order switch
        {
            StepOrder.Name => query.OrderBy(x => x.Name),
            _ => query.OrderByDescending(x => x.Created)
        };

        List<Step> result = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        int count = await query.CountAsync();
        int totalPages = (int)Math.Ceiling(count / (double)pageSize);

        return (result, count, totalPages);
    }

    public async Task<List<Step>> GetAllStepChildren(Guid recipeId, int startDepth)
    {
        return await _context.Steps.Where(x => x.RecipeId == recipeId && x.Depth >= startDepth).ToListAsync();
    }

    public async Task<List<Step>> GetStepDirectChildren(Guid recipeId, Guid? parentId)
    {
        return await _context.Steps.Where(x => x.RecipeId == recipeId && x.ParentId == parentId).ToListAsync();
    }

    public async Task<List<Step>> GetAllStepChildrenWithParameter(Guid recipeId, int startDepth)
    {
        return await _context.Steps.Where(x => x.RecipeId == recipeId && x.Depth >= startDepth)
                    .Include(x => x.StepParameters)
                        .ThenInclude(x => x.StepParameterTemplate)
                            .ThenInclude(x => x.DataType)
                    .ToListAsync();
    }

    public async Task<List<Step>> GetStepDirectChildrenWithParameter(Guid stepId)
    {
        return await _context.Steps.Where(x => x.ParentId == stepId)
                    .Include(x => x.StepParameters)
                        .ThenInclude(x => x.StepParameterTemplate)
                            .ThenInclude(x => x.DataType)
                    .ToListAsync();
    }

    public async Task<Step?> GetStep(Guid id)
    {
        return await _context.Steps.FirstOrDefaultAsync( x => x.Id == id);
    }

    public async Task<Step?> GetFullStep(Guid id)
    {
        return await _context.Steps
                    .Include(x => x.StepParameters)
                        .ThenInclude(x => x.StepParameterTemplate)
                            .ThenInclude(x => x.DataType)
                    .FirstOrDefaultAsync( x => x.Id == id);
    }

    public async Task<bool> CheckStepIdExist(Guid id)
    {
        return await _context.Steps.AnyAsync(x => x.Id == id);
    }
    
    public async Task CreateStep(Step step)
    {
        await _context.Steps.AddAsync(step);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStep(Step step)
    {
        _context.Steps.Update(step);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStepRange(List<Step> steps)
    {
        _context.Steps.UpdateRange(steps);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStep(Step step)
    {
        _context.Steps.Remove(step);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStepRange(List<Step> steps)
    {
        _context.Steps.RemoveRange(steps);
        await _context.SaveChangesAsync();
    }

    private async Task<List<Step>> getSteps(List<Guid> ids)
    {
        return await _context.Steps.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}