using RecipeApi.RecipeModule.Models.Recipe;
using RecipeApi.BaseModule.Models.Base;

namespace RecipeApi.RecipeModule.Interfaces.Services;

public interface IRecipeService
{
    Task<List<SelectDataResponse>> GetListRecipe(ListFilter filter);
    Task<PaginatedResponse<RecipeResponse>> GetPaginatedRecipe(RecipeFilter filter);
    Task<RecipeResponseSingle> GetRecipeById(Guid id);
    Task<RecipeResponse> CreateRecipe(CreateRecipeRequest model);
    Task<RecipeResponse> UpdateRecipe(Guid id, UpdateRecipeRequest model);
    Task DeleteRecipe(Guid id);

}