using Microsoft.EntityFrameworkCore;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Interfaces.Repositories;
using RecipeApi.Entities;
using RecipeApi.Helpers;
using RecipeApi.Data;
using RecipeApi.RecipeModule.Models.StepParameter;

namespace RecipeApi.RecipeModule.Repositories;

public class StepParameterRepo (
    AppDbContext context
    ) : IStepParameterRepo
{
    public readonly AppDbContext _context = context;

    public async Task<List<StepParameter>> GetAllStepParameters(ListFilter filter)
    {
        IQueryable<StepParameter> query = _context.StepParameters.AsQueryable();

        query = query.Include(x => x.StepParameterTemplate).ThenInclude(x => x.DataType);

        if (!string.IsNullOrEmpty(filter.Query))
        {
            query = query.Where(x => EF.Functions.Like(x.StepParameterTemplate.Name, $"%{filter.Query}%"));
        }

        if (filter.Limit > 0)
        {
            query = query.Take((int)filter.Limit);
        }

        List<StepParameter> types = await query.ToListAsync();

        if (!string.IsNullOrEmpty(filter.Includes))
        {
            List<Guid> guids = SiteHelper.ParseGuids(filter.Includes);

            types.AddRange(await getStepParameters(guids));
        }

        return types.Distinct().ToList();
    }

    public async Task<(List<StepParameter>, int, int)> GetPaginatedStepParameters(StepParameterFilter stepParameterFilter, int pageIndex, int pageSize)
    {
        IQueryable<StepParameter> query = _context.StepParameters.AsQueryable();

        query = query.Include(x => x.StepParameterTemplate).ThenInclude(x => x.DataType);

        if (stepParameterFilter.query != null)
        {
            query = query.Where(x => EF.Functions.Like(x.StepParameterTemplate.Name, $"%{stepParameterFilter.query}%"));
        }

        query = stepParameterFilter.order switch
        {
            StepParameterOrder.Name => query.OrderBy(x => x.StepParameterTemplate.Name),
            _ => query.OrderByDescending(x => x.Created)
        };

        List<StepParameter> result = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        int count = await query.CountAsync();
        int totalPages = (int)Math.Ceiling(count / (double)pageSize);

        return (result, count, totalPages);
    }

    public async Task<StepParameter?> GetStepParameter(Guid id)
    {
        return await _context.StepParameters.Include(x => x.StepParameterTemplate).ThenInclude(x => x.DataType).FirstOrDefaultAsync( x => x.Id == id);
    }

    public async Task<StepParameter?> GetFullStepParameter(Guid id)
    {
        return await _context.StepParameters.Include(x => x.StepParameterTemplate).ThenInclude(x => x.DataType).FirstOrDefaultAsync( x => x.Id == id);
    }

    public async Task<bool> CheckStepParameterIdExist(Guid id)
    {
        return await _context.StepParameters.AnyAsync(x => x.Id == id);
    }
    
    public async Task CreateStepParameter(StepParameter stepParameter)
    {
        await _context.StepParameters.AddAsync(stepParameter);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStepParameter(StepParameter stepParameter)
    {
        _context.StepParameters.Update(stepParameter);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStepParameter(StepParameter stepParameter)
    {
        _context.StepParameters.Remove(stepParameter);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStepParameterRange(List<StepParameter> stepParameters)
    {
        _context.StepParameters.RemoveRange(stepParameters);
        await _context.SaveChangesAsync();
    }

    private async Task<List<StepParameter>> getStepParameters(List<Guid> ids)
    {
        return await _context.StepParameters.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}