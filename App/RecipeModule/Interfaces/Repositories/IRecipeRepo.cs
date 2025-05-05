using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Models.Recipe;
using RecipeApi.Entities;

namespace RecipeApi.RecipeModule.Interfaces.Repositories;

public interface IRecipeRepo
{
    Task<List<Recipe>> GetAllRecipes(ListFilter filter);
    Task<(List<Recipe>, int, int)> GetPaginatedRecipes(RecipeFilter recipeFilter, int pageIndex, int pageSize);
    Task<Recipe?> GetRecipe(Guid id);
    Task<Recipe?> GetFullRecipe(Guid id);
    Task<bool> CheckRecipeIdExist(Guid id);
    Task CreateRecipe(Recipe recipe);
    Task UpdateRecipe(Recipe recipe);
    Task DeleteRecipe(Recipe recipe);
}