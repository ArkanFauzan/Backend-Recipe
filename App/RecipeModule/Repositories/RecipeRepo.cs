using Microsoft.EntityFrameworkCore;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Interfaces.Repositories;
using RecipeApi.RecipeModule.Models.Recipe;
using RecipeApi.Entities;
using RecipeApi.Helpers;
using RecipeApi.Data;

namespace RecipeApi.RecipeModule.Repositories;

public class RecipeRepo (
    AppDbContext context
    ) : IRecipeRepo
{
    public readonly AppDbContext _context = context;

    public async Task<List<Recipe>> GetAllRecipes(ListFilter filter)
    {
        IQueryable<Recipe> query = _context.Recipes.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Query))
        {
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{filter.Query}%"));
        }

        if (filter.Limit > 0)
        {
            query = query.Take((int)filter.Limit);
        }

        List<Recipe> types = await query.ToListAsync();

        if (!string.IsNullOrEmpty(filter.Includes))
        {
            List<Guid> guids = SiteHelper.ParseGuids(filter.Includes);

            types.AddRange(await getRecipes(guids));
        }

        return types.Distinct().ToList();
    }

    public async Task<(List<Recipe>, int, int)> GetPaginatedRecipes(RecipeFilter recipeFilter, int pageIndex, int pageSize)
    {
        IQueryable<Recipe> query = _context.Recipes.AsQueryable();

        if (recipeFilter.query != null)
        {
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{recipeFilter.query}%"));
        }

        query = recipeFilter.order switch
        {
            RecipeOrder.Name => query.OrderBy(x => x.Name),
            _ => query.OrderByDescending(x => x.Created)
        };

        List<Recipe> result = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        int count = await query.CountAsync();
        int totalPages = (int)Math.Ceiling(count / (double)pageSize);

        return (result, count, totalPages);
    }

    public async Task<Recipe?> GetRecipe(Guid id)
    {
        return await _context.Recipes.FirstOrDefaultAsync( x => x.Id == id);
    }

    public async Task<Recipe?> GetFullRecipe(Guid id)
    {
        return await _context.Recipes.FirstOrDefaultAsync( x => x.Id == id);
    }

    public async Task<bool> CheckRecipeIdExist(Guid id)
    {
        return await _context.Recipes.AnyAsync(x => x.Id == id);
    }
    
    public async Task CreateRecipe(Recipe recipe)
    {
        await _context.Recipes.AddAsync(recipe);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRecipe(Recipe recipe)
    {
        _context.Recipes.Update(recipe);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRecipe(Recipe recipe)
    {
        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();
    }

    private async Task<List<Recipe>> getRecipes(List<Guid> ids)
    {
        return await _context.Recipes.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}