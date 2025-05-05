using Microsoft.EntityFrameworkCore;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Interfaces.Repositories;
using RecipeApi.Entities;
using RecipeApi.Helpers;
using RecipeApi.Data;
using RecipeApi.RecipeModule.Models.StepParameterTemplate;

namespace RecipeApi.RecipeModule.Repositories;

public class StepParameterTemplateRepo (
    AppDbContext context
    ) : IStepParameterTemplateRepo
{
    public readonly AppDbContext _context = context;

    public async Task<List<StepParameterTemplate>> GetAllStepParameterTemplates(ListFilter filter)
    {
        IQueryable<StepParameterTemplate> query = _context.StepParameterTemplates.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Query))
        {
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{filter.Query}%"));
        }

        if (filter.Limit > 0)
        {
            query = query.Take((int)filter.Limit);
        }

        List<StepParameterTemplate> types = await query.ToListAsync();

        if (!string.IsNullOrEmpty(filter.Includes))
        {
            List<Guid> guids = SiteHelper.ParseGuids(filter.Includes);

            types.AddRange(await getStepParameterTemplates(guids));
        }

        return types.Distinct().ToList();
    }

    public async Task<(List<StepParameterTemplate>, int, int)> GetPaginatedStepParameterTemplates(StepParameterTemplateFilter stepParameterTemplateFilter, int pageIndex, int pageSize)
    {
        IQueryable<StepParameterTemplate> query = _context.StepParameterTemplates.AsQueryable();

        query = query.Include(x => x.DataType);

        if (stepParameterTemplateFilter.query != null)
        {
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{stepParameterTemplateFilter.query}%"));
        }

        query = stepParameterTemplateFilter.order switch
        {
            StepParameterTemplateOrder.Name => query.OrderBy(x => x.Name),
            _ => query.OrderByDescending(x => x.Created)
        };

        List<StepParameterTemplate> result = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        int count = await query.CountAsync();
        int totalPages = (int)Math.Ceiling(count / (double)pageSize);

        return (result, count, totalPages);
    }

    public async Task<StepParameterTemplate?> GetStepParameterTemplate(Guid id)
    {
        return await _context.StepParameterTemplates.Include(x => x.DataType).FirstOrDefaultAsync( x => x.Id == id);
    }

    public async Task<StepParameterTemplate?> GetFullStepParameterTemplate(Guid id)
    {
        return await _context.StepParameterTemplates.Include(x => x.DataType).FirstOrDefaultAsync( x => x.Id == id);
    }

    public async Task<bool> CheckStepParameterTemplateIdExist(Guid id)
    {
        return await _context.StepParameterTemplates.AnyAsync(x => x.Id == id);
    }
    
    public async Task CreateStepParameterTemplate(StepParameterTemplate stepParameterTemplate)
    {
        await _context.StepParameterTemplates.AddAsync(stepParameterTemplate);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStepParameterTemplate(StepParameterTemplate stepParameterTemplate)
    {
        _context.StepParameterTemplates.Update(stepParameterTemplate);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStepParameterTemplate(StepParameterTemplate stepParameterTemplate)
    {
        _context.StepParameterTemplates.Remove(stepParameterTemplate);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStepParameterTemplateRange(List<StepParameterTemplate> stepParameterTemplates)
    {
        _context.StepParameterTemplates.RemoveRange(stepParameterTemplates);
        await _context.SaveChangesAsync();
    }

    private async Task<List<StepParameterTemplate>> getStepParameterTemplates(List<Guid> ids)
    {
        return await _context.StepParameterTemplates.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}