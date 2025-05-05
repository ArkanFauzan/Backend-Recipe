
using AutoMapper;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Models.Recipe;
using RecipeApi.RecipeModule.Interfaces.Repositories;
using RecipeApi.RecipeModule.Interfaces.Services;
using RecipeApi.Entities;
using RecipeApi.Helpers;

namespace RecipeApi.RecipeModule.Services;

public class RecipeService(
    IMapper mapper,
    IRecipeRepo recipeRepo
) : IRecipeService 
{
    private readonly IMapper _mapper = mapper;
    private readonly IRecipeRepo _recipeRepo = recipeRepo;

    public async Task<List<SelectDataResponse>> GetListRecipe(ListFilter filter)
    {
        List<Recipe> recipes = await _recipeRepo.GetAllRecipes(filter);

        return _mapper.Map<List<SelectDataResponse>>(recipes);
    }

    public async Task<PaginatedResponse<RecipeResponse>> GetPaginatedRecipe(RecipeFilter filter)
    {
        int pageSize = SiteHelper.ValidatePageSize(filter.pageSize);
        int pageIndex = filter.page > 1 ? filter.page : 1;

        (List<Recipe> result, int count, int totalPages) = await _recipeRepo.GetPaginatedRecipes(filter, pageIndex, pageSize);

        return mappingRecipePaginatedResponse(result, pageIndex, totalPages, count);
    }

    public async Task<RecipeResponseSingle> GetRecipeById(Guid id)
    {
        Recipe recipe = await getFullRecipeById(id);
        return _mapper.Map<RecipeResponseSingle>(recipe);
    }

    public async Task<RecipeResponse> CreateRecipe(CreateRecipeRequest model)
    {
        Recipe recipe = _mapper.Map<Recipe>(model);

        await _recipeRepo.CreateRecipe(recipe);

        return _mapper.Map<RecipeResponse>(recipe);
    }

    public async Task<RecipeResponse> UpdateRecipe(Guid id, UpdateRecipeRequest model)
    {
        Recipe recipe = await getRecipe(id);
        
        recipe.Name = model.Name;

        await _recipeRepo.UpdateRecipe(recipe);

        return _mapper.Map<RecipeResponse>(recipe);
    }

    public async Task DeleteRecipe(Guid id)
    {
        Recipe recipe = await getRecipe(id);

        await _recipeRepo.DeleteRecipe(recipe);
    }

    /**
    * private methods
    */
    private PaginatedResponse<RecipeResponse> mappingRecipePaginatedResponse(IEnumerable<Recipe> recipes, int page, int totalPage, int totalCount)
    {
        PaginatedResponse<RecipeResponse> recipePaginatedResponse = new PaginatedResponse<RecipeResponse>()
        {
            Message = "success",
            Data = _mapper.Map<IEnumerable<RecipeResponse>>(recipes),
            Page = page,
            TotalPage = totalPage,
            TotalCount = totalCount
        };

        return recipePaginatedResponse;
    }

    private async Task<Recipe> getRecipe(Guid id)
    {
        Recipe recipe = await _recipeRepo.GetRecipe(id) ?? throw new KeyNotFoundException("Recipe Not Found");
        return recipe;
    }

    private async Task<Recipe> getFullRecipeById(Guid id)
    {
        Recipe recipe = await _recipeRepo.GetFullRecipe(id) ?? throw new KeyNotFoundException("Recipe Not Found");
        return recipe;
    }

}